using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalabaMVC.Migrations
{
    /// <inheritdoc />
    public partial class _44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad51e1a1-b252-43fd-adde-a6a57e359039", "AQAAAAIAAYagAAAAEE6UyOTWA7yna/sZCLA+u99OY3nlYokVMI8krDfE5aGtIlK/YmBLnRc6A2DXqqrtHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "012a0194-da7a-4779-8cf3-6a01b76f6b60", "AQAAAAIAAYagAAAAEFJwFfcNglEUmWfxEeaqxsaN2gE1XUBJ1ojGs9GB4cwt6algyfTKq+ckgqdSizCMCw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56910c11-60f0-45d4-9c30-79ab45e363d5", "AQAAAAIAAYagAAAAEAC67RSsAojdpvZHCOdaM+pflR0CWrcZDCfiFz/vAJ1N6z9LORnjbEUxRl9Kq3kZGQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "61cb32a5-7740-4134-aa64-aae78d610c3d", "AQAAAAIAAYagAAAAEAZko5FaZzG6hh6wSqLM5s7OEANaY7P/GcnOABlnf/azwDWUkOeA/Jm3QIlP5oCPIA==" });
        }
    }
}
