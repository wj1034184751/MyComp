using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20201210 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosConfig",
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
                    NetWork = table.Column<byte>(nullable: false),
                    TPDU = table.Column<string>(maxLength: 128, nullable: true),
                    Head = table.Column<string>(maxLength: 128, nullable: true),
                    CommNodeId = table.Column<string>(maxLength: 128, nullable: true),
                    HospitalId = table.Column<string>(maxLength: 128, nullable: true),
                    TerminalId = table.Column<string>(maxLength: 128, nullable: true),
                    MerchantId = table.Column<string>(maxLength: 128, nullable: true),
                    MerchantName = table.Column<string>(maxLength: 255, nullable: true),
                    IP = table.Column<string>(maxLength: 128, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Timeout = table.Column<int>(nullable: false),
                    GatewayUrl = table.Column<string>(maxLength: 512, nullable: true),
                    MainKeyIndex = table.Column<byte>(nullable: false),
                    PinKeyIndex = table.Column<byte>(nullable: false),
                    MacKeyIndex = table.Column<byte>(nullable: false),
                    TrkKeyIndex = table.Column<byte>(nullable: false),
                    KeyboardName = table.Column<string>(nullable: true),
                    FetchRecordTime = table.Column<string>(maxLength: 32, nullable: true),
                    BankType = table.Column<byte>(nullable: false),
                    Version = table.Column<string>(maxLength: 32, nullable: true),
                    EnvMode = table.Column<byte>(nullable: false),
                    DllPath = table.Column<string>(maxLength: 512, nullable: true),
                    ExePath = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosConfig", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosConfig");
        }
    }
}
