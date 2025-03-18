using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TablePerComponent.App.Migrations
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner_Address",
                table: "Dogs");

            migrationBuilder.AlterColumn<string>(
                name: "Owner_PhoneNumber",
                table: "Dogs",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Owner_Name",
                table: "Dogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Owner_Address_City",
                table: "Dogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner_Address_Line1",
                table: "Dogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner_Address_Line2",
                table: "Dogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner_Address_PostalCode",
                table: "Dogs",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner_Address_Province",
                table: "Dogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner_Address_City",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Owner_Address_Line1",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Owner_Address_Line2",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Owner_Address_PostalCode",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Owner_Address_Province",
                table: "Dogs");

            migrationBuilder.AlterColumn<string>(
                name: "Owner_PhoneNumber",
                table: "Dogs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Owner_Name",
                table: "Dogs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Owner_Address",
                table: "Dogs",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
