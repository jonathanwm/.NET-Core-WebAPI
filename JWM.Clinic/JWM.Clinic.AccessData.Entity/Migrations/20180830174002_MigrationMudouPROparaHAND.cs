using Microsoft.EntityFrameworkCore.Migrations;

namespace JWM.Clinic.AccessData.Entity.Migrations
{
    public partial class MigrationMudouPROparaHAND : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRO_OBSERVATION",
                table: "HAND_HANDBOOK",
                newName: "HAND_OBSERVATION");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HAND_OBSERVATION",
                table: "HAND_HANDBOOK",
                newName: "PRO_OBSERVATION");
        }
    }
}
