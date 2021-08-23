using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace iFridge_Backend.Migrations
{
    public partial class AddFoodsAndFridge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridgeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeID = table.Column<int>(type: "int", nullable: false),
                    OriginQTY = table.Column<int>(type: "int", nullable: false),
                    CurrentQTY = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breads_Fridges_FridgeID",
                        column: x => x.FridgeID,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fruit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeID = table.Column<int>(type: "int", nullable: false),
                    OriginQTY = table.Column<int>(type: "int", nullable: false),
                    CurrentQTY = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fruit_Fridges_FridgeID",
                        column: x => x.FridgeID,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Milks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeID = table.Column<int>(type: "int", nullable: false),
                    OriginQTY = table.Column<int>(type: "int", nullable: false),
                    CurrentQTY = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milks_Fridges_FridgeID",
                        column: x => x.FridgeID,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeID = table.Column<int>(type: "int", nullable: false),
                    OriginQTY = table.Column<int>(type: "int", nullable: false),
                    CurrentQTY = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Others_Fridges_FridgeID",
                        column: x => x.FridgeID,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seafood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeID = table.Column<int>(type: "int", nullable: false),
                    OriginQTY = table.Column<int>(type: "int", nullable: false),
                    CurrentQTY = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seafood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seafood_Fridges_FridgeID",
                        column: x => x.FridgeID,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spicess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeID = table.Column<int>(type: "int", nullable: false),
                    OriginQTY = table.Column<int>(type: "int", nullable: false),
                    CurrentQTY = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spicess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spicess_Fridges_FridgeID",
                        column: x => x.FridgeID,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFridges",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFridges", x => new { x.UserId, x.FridgeId });
                    table.ForeignKey(
                        name: "FK_UserFridges_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFridges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vegetables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeID = table.Column<int>(type: "int", nullable: false),
                    OriginQTY = table.Column<int>(type: "int", nullable: false),
                    CurrentQTY = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vegetables_Fridges_FridgeID",
                        column: x => x.FridgeID,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FridgeId",
                table: "Users",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Breads_FridgeID",
                table: "Breads",
                column: "FridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_FridgeID",
                table: "Fruit",
                column: "FridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Milks_FridgeID",
                table: "Milks",
                column: "FridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Others_FridgeID",
                table: "Others",
                column: "FridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Seafood_FridgeID",
                table: "Seafood",
                column: "FridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Spicess_FridgeID",
                table: "Spicess",
                column: "FridgeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFridges_FridgeId",
                table: "UserFridges",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_FridgeID",
                table: "Vegetables",
                column: "FridgeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Fridges_FridgeId",
                table: "Users",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Fridges_FridgeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Breads");

            migrationBuilder.DropTable(
                name: "Fruit");

            migrationBuilder.DropTable(
                name: "Milks");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Seafood");

            migrationBuilder.DropTable(
                name: "Spicess");

            migrationBuilder.DropTable(
                name: "UserFridges");

            migrationBuilder.DropTable(
                name: "Vegetables");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropIndex(
                name: "IX_Users_FridgeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FridgeId",
                table: "Users");
        }
    }
}
