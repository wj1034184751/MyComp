using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class add_digitalMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DigitalMap",
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
                    PerScale = table.Column<decimal>(type: "decimal(0, 0)", nullable: false),
                    MaxDepth = table.Column<decimal>(type: "decimal(0, 0)", nullable: false),
                    MinDepth = table.Column<decimal>(type: "decimal(0, 0)", nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    CameraX = table.Column<int>(nullable: false),
                    CameraY = table.Column<int>(nullable: false),
                    CameraZ = table.Column<int>(nullable: false),
                    BackgroundColor = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DigitalMapModel",
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
                    X = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    Y = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    Z = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    RotationX = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    RotationY = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    RotationZ = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    BackgroundImage = table.Column<string>(maxLength: 255, nullable: true),
                    BackgroundColor = table.Column<string>(maxLength: 32, nullable: true),
                    Width = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    Depth = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    ModelTypeId = table.Column<string>(maxLength: 32, nullable: true),
                    DigitalMapId = table.Column<string>(maxLength: 32, nullable: false),
                    Radius = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    Segments = table.Column<int>(nullable: false),
                    ThetaStart = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    ThetaLength = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    IsOpenEnded = table.Column<bool>(nullable: false),
                    HeightSegments = table.Column<int>(nullable: false),
                    RadiusTop = table.Column<decimal>(type: "decimal(10, 0)", nullable: false),
                    Detail = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 2048, nullable: false),
                    GroupId = table.Column<string>(maxLength: 32, nullable: false),
                    IsGroup = table.Column<bool>(nullable: false),
                    UserModelAddress = table.Column<string>(maxLength: 255, nullable: false),
                    StTerminalId = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalMapModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DigitalMap");

            migrationBuilder.DropTable(
                name: "DigitalMapModel");
        }
    }
}
