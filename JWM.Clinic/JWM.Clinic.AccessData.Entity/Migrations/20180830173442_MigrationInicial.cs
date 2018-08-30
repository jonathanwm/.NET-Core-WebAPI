using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JWM.Clinic.AccessData.Entity.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ANI_ANIMAL",
                columns: table => new
                {
                    ANI_ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ANI_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    ANI_AGE = table.Column<int>(nullable: false),
                    ANI_BREED = table.Column<string>(maxLength: 100, nullable: false),
                    ANI_NAMEOWNER = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANI_ANIMAL", x => x.ANI_ID);
                });

            migrationBuilder.CreateTable(
                name: "VET_VETERINARY",
                columns: table => new
                {
                    VET_ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MED_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    MED_SPECIALTY = table.Column<string>(maxLength: 100, nullable: false),
                    MED_NUMBERCRV = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VET_VETERINARY", x => x.VET_ID);
                });

            migrationBuilder.CreateTable(
                name: "HAND_HANDBOOK",
                columns: table => new
                {
                    HAND_ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HAND_DATE = table.Column<DateTime>(nullable: false),
                    PRO_OBSERVATION = table.Column<string>(maxLength: 100, nullable: false),
                    VET_ID = table.Column<long>(nullable: false),
                    ANI_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HAND_HANDBOOK", x => x.HAND_ID);
                    table.ForeignKey(
                        name: "FK_HAND_HANDBOOK_ANI_ANIMAL_ANI_ID",
                        column: x => x.ANI_ID,
                        principalTable: "ANI_ANIMAL",
                        principalColumn: "ANI_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HAND_HANDBOOK_VET_VETERINARY_VET_ID",
                        column: x => x.VET_ID,
                        principalTable: "VET_VETERINARY",
                        principalColumn: "VET_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HAND_HANDBOOK_ANI_ID",
                table: "HAND_HANDBOOK",
                column: "ANI_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HAND_HANDBOOK_VET_ID",
                table: "HAND_HANDBOOK",
                column: "VET_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HAND_HANDBOOK");

            migrationBuilder.DropTable(
                name: "ANI_ANIMAL");

            migrationBuilder.DropTable(
                name: "VET_VETERINARY");
        }
    }
}
