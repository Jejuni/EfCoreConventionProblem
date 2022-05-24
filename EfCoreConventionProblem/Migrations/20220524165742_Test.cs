using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreConventionProblem.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondLevelOwnedEntity_Number = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainEntities_SecondLevelOwnedEntities",
                columns: table => new
                {
                    OwnedEntityMainEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEntities_SecondLevelOwnedEntities", x => new { x.OwnedEntityMainEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_MainEntities_SecondLevelOwnedEntities_MainEntities_OwnedEntityMainEntityId",
                        column: x => x.OwnedEntityMainEntityId,
                        principalTable: "MainEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainEntities_SecondLevelOwnedEntities");

            migrationBuilder.DropTable(
                name: "OtherEntities");

            migrationBuilder.DropTable(
                name: "MainEntities");
        }
    }
}
