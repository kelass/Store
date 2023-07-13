using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characteristics_Products_ProductId",
                table: "characteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_characteristics",
                table: "characteristics");

            migrationBuilder.RenameTable(
                name: "characteristics",
                newName: "Characteristics");

            migrationBuilder.RenameIndex(
                name: "IX_characteristics_ProductId",
                table: "Characteristics",
                newName: "IX_Characteristics_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_Products_ProductId",
                table: "Characteristics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_Products_ProductId",
                table: "Characteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics");

            migrationBuilder.RenameTable(
                name: "Characteristics",
                newName: "characteristics");

            migrationBuilder.RenameIndex(
                name: "IX_Characteristics_ProductId",
                table: "characteristics",
                newName: "IX_characteristics_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_characteristics",
                table: "characteristics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_characteristics_Products_ProductId",
                table: "characteristics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
