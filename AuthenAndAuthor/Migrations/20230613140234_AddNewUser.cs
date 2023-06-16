using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenAndAuthor.Migrations
{
    public partial class AddNewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PassWord", "Role", "UserName" },
                values: new object[] { 4, "quangthai4", "Member", "quangthai4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
