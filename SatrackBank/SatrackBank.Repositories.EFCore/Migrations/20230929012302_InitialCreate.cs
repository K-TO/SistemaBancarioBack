using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatrackBank.Repositories.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    LegalRepresentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalRepresentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductStatus = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    CurrentBalance = table.Column<double>(type: "float", nullable: false),
                    Interest = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProducts",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProducts", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    PreviousBalance = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movement_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CellPhone", "CreationDate", "CustomerType", "DocumentType", "Identification", "LegalRepresentName", "LegalRepresentPhone", "Name" },
                values: new object[] { "35e0ea68-1d4a-4fa4-9132-7e47fc6d29dc", "3003974884", new DateTime(2023, 9, 28, 20, 23, 2, 271, DateTimeKind.Local).AddTicks(2750), 0, 0, "1013660386", null, null, "David Hernandez" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreationDate", "CurrentBalance", "Interest", "ProductStatus", "ProductType" },
                values: new object[] { "b4090637-a741-459d-a782-8ce8bbdcb5ec", new DateTime(2023, 9, 28, 20, 23, 2, 271, DateTimeKind.Local).AddTicks(2867), 1000000.0, 0.040000000000000001, 0, 0 });

            migrationBuilder.InsertData(
                table: "CustomerProducts",
                columns: new[] { "CustomerId", "ProductId" },
                values: new object[] { "35e0ea68-1d4a-4fa4-9132-7e47fc6d29dc", "b4090637-a741-459d-a782-8ce8bbdcb5ec" });

            migrationBuilder.InsertData(
                table: "Movement",
                columns: new[] { "Id", "Date", "Description", "MovementType", "PreviousBalance", "ProductId", "Value" },
                values: new object[] { "3a60defa-5bd3-4fdc-b02e-d4bc7ce0ba4f", new DateTime(2023, 9, 28, 20, 23, 2, 271, DateTimeKind.Local).AddTicks(2891), "Creación de cuenta.", 6, 0.0, "b4090637-a741-459d-a782-8ce8bbdcb5ec", 1000000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CustomerId",
                table: "CustomerProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_ProductId",
                table: "Movement",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProducts");

            migrationBuilder.DropTable(
                name: "Movement");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
