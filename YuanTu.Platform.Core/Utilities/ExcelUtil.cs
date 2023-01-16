using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace YuanTu.Platform.Utilities
{
    /// <summary>
    /// EXCEL通用处理类
    /// </summary>
    public static class ExcelUtil
    {
        static ExcelUtil()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileOutputUtil.OutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}excels");
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="file"></param>
        /// <param name="columnsMapping"></param>
        public static async Task<IEnumerable<TEntity>> ImportAsync<TEntity>(IFormFile file, Dictionary<string, string> columnsMapping) where TEntity : class, new()
        {
            var result = new List<TEntity>();
            var ext = Path.GetExtension(file.FileName);
            if (!".xls".Equals(ext) && !".xlsx".Equals(ext) && !".csv".Equals(ext)) return result;

            await using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
              
            using var package = new ExcelPackage(ms);

            var worksheet = package.Workbook.Worksheets[0];
            var rows = worksheet.Dimension.Rows;
            var cols = worksheet.Dimension.Columns;
            var props = typeof(TEntity).GetProperties();

            for (var i = 2; i <= rows; i++)
            {
                var model = new TEntity();
                for (var j = 1; j <= cols; j++)
                {
                    var key = worksheet.Cells[1, j].Value.ToString();
                    foreach (var propertyInfo in props)
                    { 
                        if (columnsMapping.ContainsKey(key) && propertyInfo.Name.Equals(columnsMapping[key]))
                        {
                            propertyInfo.SetValue(model, Convert.ChangeType(worksheet.Cells[i, j].Value, propertyInfo.PropertyType));
                            break;
                        }
                    }
                }
                result.Add(model);
            } 

            return result;
        }

        /// <summary>
        /// 导出数据
        /// </summary> 
        /// <param name="fileName">自定义文件名</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="columns">表头项</param>
        public static async Task<(string, string)> ExportAsync<T>(string fileName, IEnumerable<T> dataSource, List<string> columns)
        {
            var fileInfo = FileOutputUtil.GetFileInfo($"{(string.IsNullOrWhiteSpace(fileName) ? Guid.NewGuid().ToString() : fileName)}.xlsx");
            using var package = new ExcelPackage(fileInfo);

            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            //设置表头
            for (var i = 0; i < columns.Count; i++)
                worksheet.Cells[1, i + 1].Value = columns[i];

            //内容  
            worksheet.Cells["A2"].LoadFromCollection(dataSource);
            worksheet.Cells.AutoFitColumns();

            await package.SaveAsync();

            return (fileInfo.Name, fileInfo.FullName);
        }
    }
}