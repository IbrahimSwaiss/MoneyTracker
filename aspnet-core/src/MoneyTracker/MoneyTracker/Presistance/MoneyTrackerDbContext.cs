﻿using Microsoft.EntityFrameworkCore;
using MoneyTracker.Models;
using MoneyTracker.Presistance.Configurations;

namespace MoneyTracker.Presistance {
    public class MoneyTrackerDbContext : DbContext {
        public MoneyTrackerDbContext(DbContextOptions<MoneyTrackerDbContext> options) : base(options) { }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new BudgetEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());
        }
    }
}
