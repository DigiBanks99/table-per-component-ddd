using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TablePerComponent.App.Migrations
{
    /// <inheritdoc />
    public partial class OverrideNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Owner_PhoneNumber",
                table: "Dogs",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Owner_PassportNumber",
                table: "Dogs",
                newName: "PassportNumber");

            migrationBuilder.RenameColumn(
                name: "Owner_Name",
                table: "Dogs",
                newName: "Owner");

            migrationBuilder.RenameColumn(
                name: "Owner_IdType",
                table: "Dogs",
                newName: "IdType");

            migrationBuilder.RenameColumn(
                name: "Owner_IdNumber",
                table: "Dogs",
                newName: "IdNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Dogs",
                newName: "Owner_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "Dogs",
                newName: "Owner_PassportNumber");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Dogs",
                newName: "Owner_Name");

            migrationBuilder.RenameColumn(
                name: "IdType",
                table: "Dogs",
                newName: "Owner_IdType");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "Dogs",
                newName: "Owner_IdNumber");
        }
    }
}
