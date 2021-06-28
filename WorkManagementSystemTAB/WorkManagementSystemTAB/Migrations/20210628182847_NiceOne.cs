using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkManagementSystemTAB.Migrations
{
    public partial class NiceOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_AbsenceTypes_AbsenceTypeId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Users_UserId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktimes_Users_UserId",
                table: "Worktimes");

            migrationBuilder.DropIndex(
                name: "IX_Worktimes_UserId",
                table: "Worktimes");

            migrationBuilder.DropIndex(
                name: "IX_Absences_AbsenceTypeId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_UserId",
                table: "Absences");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Worktimes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Absences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AbsenceTypeId",
                table: "Absences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Worktimes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Absences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AbsenceTypeId",
                table: "Absences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Worktimes_UserId",
                table: "Worktimes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_AbsenceTypeId",
                table: "Absences",
                column: "AbsenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_UserId",
                table: "Absences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_AbsenceTypes_AbsenceTypeId",
                table: "Absences",
                column: "AbsenceTypeId",
                principalTable: "AbsenceTypes",
                principalColumn: "AbsenceTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Users_UserId",
                table: "Absences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktimes_Users_UserId",
                table: "Worktimes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
