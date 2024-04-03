using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QnSchool.Migrations
{
    /// <inheritdoc />
    public partial class InitRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] {"Id","Name", "NormalizedName" },
            values: new object[] { Guid.NewGuid().ToString(), "GVCN", "GIÁO VIÊN CHỦ NHIỆM" }
            );
            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName" },
            values: new object[] { Guid.NewGuid().ToString(), "HS", "HỌC SINH" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AspNetRoles");
        }
    }
}
