using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuoteManagement.Models;

namespace QuoteManagement.Data
{
    public class QuoteManagementContext : DbContext
    {
        public QuoteManagementContext (DbContextOptions<QuoteManagementContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=QuoteManagementContext-7baf3f05-2432-458c-a7ed-171de35efb98;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<QuoteManagement.Models.QuoteDetails> QuoteDetails { get; set; }
    }
}
