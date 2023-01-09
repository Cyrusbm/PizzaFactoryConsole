using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaFactory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpricetopping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Toppings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Toppings");
        }
    }
}
