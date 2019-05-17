using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyTracker.Migrations
{
    public partial class AddBudgetsAndTransactionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    MonthlyBudget = table.Column<decimal>(nullable: false),
                    WeeklyBudget = table.Column<decimal>(nullable: false),
                    MonthlySavingAmount = table.Column<decimal>(nullable: false),
                    MonthlySavingPercentage = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Repeat = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    BudgetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BudgetId",
                table: "Transactions",
                column: "BudgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Budgets");
        }
    }
}
