﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_6.Migrations
{
    /// <inheritdoc />
    public partial class user_password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pass",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pass",
                table: "Users");
        }
    }
}
