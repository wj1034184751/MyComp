using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class pos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnionConfigData",
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
                    ServerIP = table.Column<string>(nullable: true),
                    ServerPort = table.Column<string>(nullable: true),
                    TimeOut = table.Column<string>(nullable: true),
                    TPDU = table.Column<string>(nullable: true),
                    Head = table.Column<string>(nullable: true),
                    TerminalId = table.Column<string>(nullable: true),
                    MerchantId = table.Column<string>(nullable: true),
                    MerchantName = table.Column<string>(nullable: true),
                    MKey = table.Column<string>(nullable: true),
                    MainKeyIndex = table.Column<int>(nullable: false),
                    PinKeyIndex = table.Column<int>(nullable: false),
                    MacKeyIndex = table.Column<int>(nullable: false),
                    TrkKeyIndex = table.Column<string>(nullable: true),
                    BankType = table.Column<string>(nullable: true),
                    CardReaderName = table.Column<string>(nullable: true),
                    Inhale = table.Column<string>(nullable: true),
                    CardReaderPort = table.Column<string>(nullable: true),
                    CardReaderBaud = table.Column<string>(nullable: true),
                    AutoEject = table.Column<string>(nullable: true),
                    MKeyboardName = table.Column<string>(nullable: true),
                    MKeyboardPort = table.Column<string>(nullable: true),
                    MKeyboardBaud = table.Column<string>(nullable: true),
                    EnvMode = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionConfigData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnionTransData",
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
                    PlatformNo = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    BankType = table.Column<string>(maxLength: 256, nullable: true),
                    MerchantId = table.Column<string>(maxLength: 256, nullable: true),
                    TerminalId = table.Column<string>(maxLength: 256, nullable: true),
                    IPAndPort = table.Column<string>(maxLength: 256, nullable: true),
                    TPDU = table.Column<string>(maxLength: 256, nullable: true),
                    CallType = table.Column<string>(maxLength: 256, nullable: true),
                    HospitalId = table.Column<string>(maxLength: 256, nullable: true),
                    PatientId = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(maxLength: 256, nullable: true),
                    IdNo = table.Column<string>(maxLength: 256, nullable: true),
                    Source = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(maxLength: 256, nullable: true),
                    TradeType = table.Column<string>(maxLength: 256, nullable: true),
                    FeeChannel = table.Column<string>(maxLength: 256, nullable: true),
                    PayState = table.Column<int>(nullable: false),
                    PayTime = table.Column<DateTime>(nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    BankPayNo = table.Column<string>(maxLength: 256, nullable: true),
                    AuthorizeNo = table.Column<string>(maxLength: 256, nullable: true),
                    LotId = table.Column<string>(maxLength: 256, nullable: true),
                    IssuerCode = table.Column<string>(maxLength: 256, nullable: true),
                    IssuerName = table.Column<string>(maxLength: 256, nullable: true),
                    CardValidDate = table.Column<DateTime>(nullable: false),
                    DeviceIp = table.Column<string>(maxLength: 256, nullable: true),
                    Element = table.Column<string>(maxLength: 4000, nullable: true),
                    ResquestContext = table.Column<string>(maxLength: 256, nullable: true),
                    ResponseContext = table.Column<string>(maxLength: 256, nullable: true),
                    Extend = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionTransData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnionConfigData");

            migrationBuilder.DropTable(
                name: "UnionTransData");
        }
    }
}
