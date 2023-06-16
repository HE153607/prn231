using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenAndAuthor.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PassWord", "Role", "UserName" },
                values: new object[] { 1, "hungbao1", "Admin", "hungbao1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PassWord", "Role", "UserName" },
                values: new object[] { 2, "hoanganh2", "Admin", "hoanganh2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PassWord", "Role", "UserName" },
                values: new object[] { 3, "minhhoang3", "Member", "minhhoang3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
