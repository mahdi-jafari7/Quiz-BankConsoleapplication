using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BankConsoleApp.configuration;
using BankConsoleApp.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;



namespace BankConsoleApp.DbContext
{
    public class BankDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextConfiguration.Configure(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Transaction>()
                .HasOne(b => b.forCard)
                .WithMany(u => u.transactions)
                .HasForeignKey(b => b.TransactionId);

            modelBuilder.Entity<Card>().HasData(
            new Card
            {
                Id = 1,
                CardNumber = "1234567812345678",
                HolderName = "علی احمدی",
                Balance = 1000.0f,
                IsActive = true,
                Password = "password123",
                TryToEnterTimes = 0
            },
            new Card
            {
                Id = 2,
                CardNumber = "2345678923456789",
                HolderName = "مریم محمدی",
                Balance = 1500.0f,
                IsActive = true,
                Password = "password456",
                TryToEnterTimes = 0
            },
            new Card
            {
                Id = 3,
                CardNumber = "3456789034567890",
                HolderName = "رضا حسینی",
                Balance = 2000.0f,
                IsActive = true,
                Password = "password789",
                TryToEnterTimes = 0
            },
            new Card
            {
                Id = 4,
                CardNumber = "4567890145678901",
                HolderName = "سارا کریمی",
                Balance = 2500.0f,
                IsActive = true,
                Password = "password101",
                TryToEnterTimes = 0
            },
            new Card
            {
                Id = 5,
                CardNumber = "5678901256789012",
                HolderName = "حسین سلطانی",
                Balance = 3000.0f,
                IsActive = true,
                Password = "password202",
                TryToEnterTimes = 0
            }
        );
         
            base.OnModelCreating(modelBuilder);
        }
    }
}
