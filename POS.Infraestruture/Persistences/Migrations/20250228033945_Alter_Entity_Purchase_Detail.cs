﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Infraestructure.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Entity_Purchase_Detail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurcharseDetails_Products_ProductId",
                table: "PurcharseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK__Purcharse__Purch__6754599E",
                table: "PurcharseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharses_Providers_ProviderId",
                table: "Purcharses");

            migrationBuilder.DropForeignKey(
                name: "FK__Purcharse__UserI__693CA210",
                table: "Purcharses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Purchars__A98C674B1032F6BF",
                table: "Purcharses");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Purchars__7353248B683F784C",
                table: "PurcharseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurcharseDetails_PurcharseId",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "PurcharseDate",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "PurcharseDetailId",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "AuditCreateDate",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "AuditCreateUser",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "AuditDeleteDate",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "AuditDeleteUser",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "AuditUpdateDate",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "AuditUpdateUser",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PurcharseDetails");

            migrationBuilder.RenameColumn(
                name: "PurcharseId",
                table: "Purcharses",
                newName: "WarehouseId");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Purcharses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Purcharses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);


            migrationBuilder.AddColumn<int>(
                name: "NewWarehouseId",
                table: "Purcharses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Purcharses SET NewWarehouseId = WarehouseId");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Purcharses");

            migrationBuilder.RenameColumn(
                name: "NewWarehouseId",
                table: "Purcharses",
                newName: "WarehouseId");


            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Purcharses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "Igv",
                table: "Purcharses",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Purcharses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Purcharses",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Purcharses",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PurcharseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurcharseId",
                table: "PurcharseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PurcharseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "PurcharseDetails",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPurchasePrice",
                table: "PurcharseDetails",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purcharses",
                table: "Purcharses",
                column: "PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurcharseDetails",
                table: "PurcharseDetails",
                columns: new[] { "PurcharseId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Purcharses_WarehouseId",
                table: "Purcharses",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurcharseDetails_Products_ProductId",
                table: "PurcharseDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurcharseDetails_Purcharses_PurcharseId",
                table: "PurcharseDetails",
                column: "PurcharseId",
                principalTable: "Purcharses",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharses_Providers_ProviderId",
                table: "Purcharses",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharses_Users_UserId",
                table: "Purcharses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharses_Warehouses_WarehouseId",
                table: "Purcharses",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurcharseDetails_Products_ProductId",
                table: "PurcharseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurcharseDetails_Purcharses_PurcharseId",
                table: "PurcharseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharses_Providers_ProviderId",
                table: "Purcharses");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharses_Users_UserId",
                table: "Purcharses");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharses_Warehouses_WarehouseId",
                table: "Purcharses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purcharses",
                table: "Purcharses");

            migrationBuilder.DropIndex(
                name: "IX_Purcharses_WarehouseId",
                table: "Purcharses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurcharseDetails",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "Igv",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Purcharses");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "PurcharseDetails");

            migrationBuilder.DropColumn(
                name: "UnitPurchasePrice",
                table: "PurcharseDetails");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Purcharses",
                newName: "PurcharseId");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Purcharses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Purcharses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurcharseId",
                table: "Purcharses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurcharseDate",
                table: "Purcharses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Purcharses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Purcharses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PurcharseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PurcharseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurcharseId",
                table: "PurcharseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PurcharseDetailId",
                table: "PurcharseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditCreateDate",
                table: "PurcharseDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AuditCreateUser",
                table: "PurcharseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditDeleteDate",
                table: "PurcharseDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditDeleteUser",
                table: "PurcharseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditUpdateDate",
                table: "PurcharseDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditUpdateUser",
                table: "PurcharseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PurcharseDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Purchars__A98C674B1032F6BF",
                table: "Purcharses",
                column: "PurcharseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Purchars__7353248B683F784C",
                table: "PurcharseDetails",
                column: "PurcharseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurcharseDetails_PurcharseId",
                table: "PurcharseDetails",
                column: "PurcharseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurcharseDetails_Products_ProductId",
                table: "PurcharseDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK__Purcharse__Purch__6754599E",
                table: "PurcharseDetails",
                column: "PurcharseId",
                principalTable: "Purcharses",
                principalColumn: "PurcharseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharses_Providers_ProviderId",
                table: "Purcharses",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK__Purcharse__UserI__693CA210",
                table: "Purcharses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
