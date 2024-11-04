using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gym_master.Migrations
{
    /// <inheritdoc />
    public partial class AddTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastPayMentDate",
                table: "UserServices",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPayMentDate",
                table: "UserServices");
        }
    }
}
