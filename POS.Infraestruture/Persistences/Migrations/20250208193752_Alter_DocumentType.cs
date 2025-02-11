using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Infraestructure.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class Alter_DocumentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminar claves foráneas en Providers y Clients
            migrationBuilder.DropForeignKey(
                name: "FK__Providers__Docum__6477ECF3",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK__Clients__Documen__5EBF139D",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Document__DBA390E18BE99EFE",
                table: "DocumentTypes");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "DocumentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditCreateDate",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AuditCreateUser",
                table: "DocumentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditDeleteDate",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditDeleteUser",
                table: "DocumentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditUpdateDate",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditUpdateUser",
                table: "DocumentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes",
                column: "DocumentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "AuditCreateDate",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "AuditCreateUser",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "AuditDeleteDate",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "AuditDeleteUser",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "AuditUpdateDate",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "AuditUpdateUser",
                table: "DocumentTypes");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "DocumentTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Document__DBA390E18BE99EFE",
                table: "DocumentTypes",
                column: "DocumentTypeId");
        }
    }
}
