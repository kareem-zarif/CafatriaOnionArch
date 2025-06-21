using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cafe.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntitesseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<byte>(type: "tinyint", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OpenAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    CloseAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(265)", maxLength: 265, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(46)", maxLength: 46, nullable: false),
                    Capacity = table.Column<byte>(type: "tinyint", nullable: false),
                    TableStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RemainInStock = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchesSupplier",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastDeal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HistoryOfDeal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesSupplier", x => new { x.BranchId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_BranchesSupplier_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchesSupplier_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: false),
                    OrderedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    ItemNotes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CloseAt", "CreatedBy", "CreatedOn", "Location", "ManagerName", "ModifiedBy", "ModifiedOn", "OpenAt", "Phone" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "123 Main St", new TimeOnly(18, 0, 0), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), (byte)2, "Alice", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(8, 0, 0), "01212345678" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "456 Side St", new TimeOnly(17, 0, 0), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), (byte)4, "Bob", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeOnly(9, 0, 0), "01012345678" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "MenuName", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Breakfast", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Lunch", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "phone" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), "789 Supplier Ave", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Fresh Foods Co.", "01234567890" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "1010 Market St", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Quality Supplies Ltd.", "01123456789" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Capacity", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "TableName", "TableStatus" },
                values: new object[,]
                {
                    { new Guid("11111111-aaaa-aaaa-aaaa-111111111111"), (byte)4, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Table 1", (byte)1 },
                    { new Guid("22222222-aaaa-aaaa-aaaa-222222222222"), (byte)6, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Table 2", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "BranchesSupplier",
                columns: new[] { "BranchId", "SupplierId", "CreatedBy", "CreatedOn", "HistoryOfDeal", "Id", "LastDeal", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("66666666-6666-6666-6666-666666666666"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "[]", new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BranchId", "CreatedBy", "CreatedOn", "Email", "HireDate", "IsActive", "ModifiedBy", "ModifiedOn", "Name", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", new DateOnly(2022, 1, 10), true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "john.doe@example.com", (byte)2 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", new DateOnly(2023, 2, 15), true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", "jane.smith@example.com", (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "OrderStatus", "OrderedOn", "TableId", "TotalMoney" },
                values: new object[,]
                {
                    { new Guid("a9999999-aaaa-aaaa-9999-99999999999a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, new DateTime(2024, 6, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111111-aaaa-aaaa-aaaa-111111111111"), 100.0 },
                    { new Guid("b9999999-aaaa-aaaa-9999-99999999999b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), (byte)3, new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22222222-aaaa-aaaa-aaaa-222222222222"), 150.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedBy", "CreatedOn", "Description", "IsAvailable", "MenuId", "ModifiedBy", "ModifiedOn", "Name", "Price", "RemainInStock" },
                values: new object[,]
                {
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), (byte)0, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new Guid("88888888-8888-8888-8888-888888888888"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burger", 25.0, 0 },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), (byte)0, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new Guid("88888888-8888-8888-8888-888888888888"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pizza", 50.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ItemNotes", "ModifiedBy", "ModifiedOn", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("c9999999-aaaa-aaaa-9999-99999999999c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "No onions", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a9999999-aaaa-aaaa-9999-99999999999a"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), 2, 25.0 },
                    { new Guid("d9999999-aaaa-aaaa-9999-99999999999d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Extra cheese", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9999999-aaaa-aaaa-9999-99999999999b"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), 3, 50.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchesSupplier_SupplierId",
                table: "BranchesSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedOn",
                table: "Orders",
                column: "OrderedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsAvailable_Category",
                table: "Products",
                columns: new[] { "IsAvailable", "Category" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MenuId",
                table: "Products",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TableStatus",
                table: "Tables",
                column: "TableStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchesSupplier");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
