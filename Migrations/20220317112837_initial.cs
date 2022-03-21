using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailySharePriceApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mutualFundPriceDetails",
                columns: table => new
                {
                    MutualFundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MutualFundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MutualFundPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mutualFundPriceDetails", x => x.MutualFundId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioDetails",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioDetails", x => x.PortfolioId);
                    table.ForeignKey(
                        name: "FK_portfolioDetails_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mutualFundDetails",
                columns: table => new
                {
                    MutualFunBuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    MutualFundId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mutualFundDetails", x => x.MutualFunBuyId);
                    table.ForeignKey(
                        name: "FK_mutualFundDetails_mutualFundPriceDetails_MutualFundId",
                        column: x => x.MutualFundId,
                        principalTable: "mutualFundPriceDetails",
                        principalColumn: "MutualFundId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mutualFundDetails_portfolioDetails_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "portfolioDetails",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stockDetails",
                columns: table => new
                {
                    StockBuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockDetails", x => x.StockBuyId);
                    table.ForeignKey(
                        name: "FK_stockDetails_portfolioDetails_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "portfolioDetails",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stockDetails_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mutualFundDetails_MutualFundId",
                table: "mutualFundDetails",
                column: "MutualFundId");

            migrationBuilder.CreateIndex(
                name: "IX_mutualFundDetails_PortfolioId",
                table: "mutualFundDetails",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioDetails_UserId",
                table: "portfolioDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_stockDetails_PortfolioId",
                table: "stockDetails",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_stockDetails_StockId",
                table: "stockDetails",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mutualFundDetails");

            migrationBuilder.DropTable(
                name: "stockDetails");

            migrationBuilder.DropTable(
                name: "mutualFundPriceDetails");

            migrationBuilder.DropTable(
                name: "portfolioDetails");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
