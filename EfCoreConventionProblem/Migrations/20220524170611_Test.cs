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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnedEntity_Number = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherEntities_OwnedEntities",
                columns: table => new
                {
                    OtherEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEntities_OwnedEntities", x => new { x.OtherEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_OtherEntities_OwnedEntities_OtherEntities_OtherEntityId",
                        column: x => x.OtherEntityId,
                        principalTable: "OtherEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainEntities");

            migrationBuilder.DropTable(
                name: "OtherEntities_OwnedEntities");

            migrationBuilder.DropTable(
                name: "OtherEntities");
        }
    }
}
