using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatrackBank.Repositories.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class JwtAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { "35e0ea68-1d4a-4fa4-9132-7e47fc6d29dc", "b4090637-a741-459d-a782-8ce8bbdcb5ec" });

            migrationBuilder.DeleteData(
                table: "Movement",
                keyColumn: "Id",
                keyValue: "3a60defa-5bd3-4fdc-b02e-d4bc7ce0ba4f");

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: "35e0ea68-1d4a-4fa4-9132-7e47fc6d29dc");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "b4090637-a741-459d-a782-8ce8bbdcb5ec");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CellPhone", "CreationDate", "CustomerType", "DocumentType", "Identification", "LegalRepresentName", "LegalRepresentPhone", "Name", "Password" },
                values: new object[] { "e265fcfe-b0ff-4125-bf43-67201a2fa7d9", "3000000000", new DateTime(2023, 9, 30, 15, 15, 7, 979, DateTimeKind.Local).AddTicks(5792), 0, 0, "1013666666", null, null, "John Doe", "$2a$11$aMvcvJ6t0xJCZZ/TMkfqo.hbGthbZ8l6osZajcJXdEenVKlghatEy" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreationDate", "CurrentBalance", "Interest", "ProductStatus", "ProductType" },
                values: new object[] { "819d08db-c025-4a01-84a7-d305338d4244", new DateTime(2023, 9, 30, 15, 15, 7, 979, DateTimeKind.Local).AddTicks(5878), 1000000.0, 0.040000000000000001, 0, 0 });

            migrationBuilder.InsertData(
                table: "CustomerProducts",
                columns: new[] { "CustomerId", "ProductId" },
                values: new object[] { "e265fcfe-b0ff-4125-bf43-67201a2fa7d9", "819d08db-c025-4a01-84a7-d305338d4244" });

            migrationBuilder.InsertData(
                table: "Movement",
                columns: new[] { "Id", "Date", "Description", "MovementType", "PreviousBalance", "ProductId", "Value" },
                values: new object[] { "a9197ad9-8101-42d0-9b4a-f1097d7675e1", new DateTime(2023, 9, 30, 15, 15, 7, 979, DateTimeKind.Local).AddTicks(5897), "Creación de cuenta.", 6, 0.0, "819d08db-c025-4a01-84a7-d305338d4244", 1000000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerProducts",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { "e265fcfe-b0ff-4125-bf43-67201a2fa7d9", "819d08db-c025-4a01-84a7-d305338d4244" });

            migrationBuilder.DeleteData(
                table: "Movement",
                keyColumn: "Id",
                keyValue: "a9197ad9-8101-42d0-9b4a-f1097d7675e1");

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: "e265fcfe-b0ff-4125-bf43-67201a2fa7d9");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "819d08db-c025-4a01-84a7-d305338d4244");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customer");

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
        }
    }
}
