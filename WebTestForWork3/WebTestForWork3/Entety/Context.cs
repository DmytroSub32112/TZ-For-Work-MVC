using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestForWork3.Models;

namespace WebTestForWork3.Entety
{
    public class Context : DbContext
    {
        public DbSet<Order> Orders{ get; set;}
        public DbSet<OrderPosition> OrderPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = ordersforcustomerdb; Trusted_Connection=True");
        }
    }
}
