using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskDAL.Migrations
{
    /// <inheritdoc />
    public partial class changedanswerandtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RightAnswerId",
                table: "Questions");

            migrationBuilder.AddColumn<bool>(
                name: "IsRight",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRight",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "RightAnswerId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
