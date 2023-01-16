using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20201125 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosTrade",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    OrgId = table.Column<long>(nullable: false),
                    PlatformNo = table.Column<string>(maxLength: 255, nullable: false),
                    OrgPlatformNo = table.Column<string>(maxLength: 255, nullable: true),
                    PayState = table.Column<int>(nullable: false),
                    TradeType = table.Column<int>(nullable: false),
                    BankPayNo = table.Column<string>(maxLength: 255, nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    CardNo = table.Column<string>(maxLength: 255, nullable: true),
                    PayTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Msg = table.Column<string>(maxLength: 255, nullable: true),
                    MAC = table.Column<string>(maxLength: 255, nullable: true),
                    CPUTlv = table.Column<string>(maxLength: 2048, nullable: true),
                    Track2 = table.Column<string>(maxLength: 255, nullable: true),
                    Track3 = table.Column<string>(maxLength: 255, nullable: true),
                    Extend = table.Column<string>(maxLength: 2048, nullable: true),
                    CardSNum = table.Column<string>(maxLength: 255, nullable: true),
                    CardValidDate = table.Column<string>(maxLength: 255, nullable: true),
                    PayMethod = table.Column<string>(maxLength: 255, nullable: true),
                    Element = table.Column<string>(maxLength: 2048, nullable: true),
                    IssuerCode = table.Column<string>(maxLength: 255, nullable: true),
                    IssuerName = table.Column<string>(maxLength: 255, nullable: true),
                    LotId = table.Column<string>(maxLength: 255, nullable: true),
                    TerminalID = table.Column<string>(maxLength: 255, nullable: true),
                    MerchantID = table.Column<string>(maxLength: 255, nullable: true),
                    AuthorizeNo = table.Column<string>(maxLength: 255, nullable: true),
                    Psd = table.Column<string>(maxLength: 255, nullable: true),
                    FinishTime = table.Column<DateTime>(nullable: true),
                    Extend2 = table.Column<string>(maxLength: 2048, nullable: true),
                    Extend3 = table.Column<string>(maxLength: 2048, nullable: true),
                    Extend4 = table.Column<string>(maxLength: 2048, nullable: true),
                    Extend5 = table.Column<string>(maxLength: 2048, nullable: true),
                    IsSuccess = table.Column<bool>(nullable: false),
                    HospitalId = table.Column<string>(maxLength: 2048, nullable: true),
                    PatientId = table.Column<string>(maxLength: 2048, nullable: true),
                    PatientName = table.Column<string>(maxLength: 2048, nullable: true),
                    IdNo = table.Column<string>(maxLength: 2048, nullable: true),
                    Source = table.Column<string>(maxLength: 2048, nullable: true),
                    FeeChannel = table.Column<string>(maxLength: 2048, nullable: true),
                    DeviceIp = table.Column<string>(maxLength: 2048, nullable: true),
                    DeviceMAC = table.Column<string>(maxLength: 2048, nullable: true),
                    Num = table.Column<int>(nullable: false),
                    HisCode = table.Column<string>(maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosTrade", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosTrade");
        }
    }
}
