using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Em;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        /// <summary>
        /// 题库表
        /// </summary>
        public DbSet<Em_Question> Em_Question { get; set; }

        /// <summary>
        /// 题库答案表
        /// </summary>
        public DbSet<Em_Question_Answer> Em_Question_Answer { get; set; }

        /// <summary>
        /// 考卷配置
        /// </summary>
        public DbSet<Em_Exam_Config> Em_Exam_Config { get; set; }

        /// <summary>
        /// 考卷大纲配置
        /// </summary>
        public DbSet<Em_Exam_Outline_Config> Em_Exam_Outline_Config { get; set; }

        /// <summary>
        /// 大纲题目配置
        /// </summary>
        public DbSet<Em_Exam_Outline_Question_Config> Em_Exam_Outline_Question_Config { get; set; }

        public DbSet<Em_Exam_Result> Em_Exam_Result { get; set; }

        public DbSet<Em_Exam_Result_Outline> Em_Exam_Result_Outline { get; set; }

        public DbSet<Em_Exam_Result_Outline_Question> Em_Exam_Result_Outline_Question { get; set; }
    }
}