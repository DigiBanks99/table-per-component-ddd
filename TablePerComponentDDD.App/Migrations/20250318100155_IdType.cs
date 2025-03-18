using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TablePerComponent.App.Migrations
{
    /// <inheritdoc />
    public partial class IdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner_IdNumber",
                table: "Dogs",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner_IdType",
                table: "Dogs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner_PassportNumber",
                table: "Dogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner_IdNumber",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Owner_IdType",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Owner_PassportNumber",
                table: "Dogs");
        }
    }
}
