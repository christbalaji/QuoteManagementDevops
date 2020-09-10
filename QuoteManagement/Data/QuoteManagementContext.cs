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

        public DbSet<QuoteManagement.Models.QuoteDetails> QuoteDetails { get; set; }
    }
}
