using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillQuizLight.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "tUsr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "tUsr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "tUsr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatUsrID",
                table: "tUsr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActivate",
                table: "tUsr",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tUsr",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "tUsr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifUsrID",
                table: "tUsr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParamLangID",
                table: "tUsr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParamUsrTypeID",
                table: "tUsr",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "CreatUsrID",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "IsActivate",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "ModifUsrID",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "ParamLangID",
                table: "tUsr");

            migrationBuilder.DropColumn(
                name: "ParamUsrTypeID",
                table: "tUsr");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "tUsr",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
