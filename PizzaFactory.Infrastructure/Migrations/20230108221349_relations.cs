using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaFactory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beverages_Orders_OrderId",
                table: "Beverages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Orders_OrderId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_OrderId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Beverages_OrderId",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Beverages");

            migrationBuilder.CreateTable(
                name: "BeverageOrder",
                columns: table => new
                {
                    BeveragesId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeverageOrder", x => new { x.BeveragesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_BeverageOrder_Beverages_BeveragesId",
                        column: x => x.BeveragesId,
                        principalTable: "Beverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeverageOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false),
                    PizzasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => new { x.OrdersId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_OrderPizza_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizzas_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTopping",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToppingsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTopping", x => new { x.OrdersId, x.ToppingsId });
                    table.ForeignKey(
                        name: "FK_OrderTopping_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTopping_Toppings_ToppingsId",
                        column: x => x.ToppingsId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeverageOrder_OrdersId",
                table: "BeverageOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzasId",
                table: "OrderPizza",
                column: "PizzasId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTopping_ToppingsId",
                table: "OrderTopping",
                column: "ToppingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeverageOrder");

            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "OrderTopping");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Toppings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Pizzas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Beverages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_OrderId",
                table: "Toppings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizzas",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Beverages_OrderId",
                table: "Beverages",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beverages_Orders_OrderId",
                table: "Beverages",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderId",
                table: "Pizzas",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Orders_OrderId",
                table: "Toppings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
