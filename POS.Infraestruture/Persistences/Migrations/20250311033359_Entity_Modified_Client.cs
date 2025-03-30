using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Infraestructure.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class Entity_Modified_Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Sales__ClientId__6C190EBB",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Clients__E67E1A24A554C60B",
                table: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Clients_ClientId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Clients__E67E1A24A554C60B",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK__Sales__ClientId__6C190EBB",
                table: "Sales",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");
        }
    }
}
