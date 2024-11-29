using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.configuration
{
    public static class DbContextConfiguration
    {
        public static void Configure(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-01HRT8HI\\SQLEXPRESS;Database=BankDbContext;Integrated Security=true;TrustServerCertificate=True");
        }
    }

}
