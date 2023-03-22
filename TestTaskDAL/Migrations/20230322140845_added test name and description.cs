using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskDAL.Migrations
{
    /// <inheritdoc />
    public partial class addedtestnameanddescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tests");
        }
    }
}
