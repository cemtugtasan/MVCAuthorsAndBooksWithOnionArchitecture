using Microsoft.EntityFrameworkCore;
using MvcOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Infrustructure.ModelContext
{
    public class ApplicationDbContext : DbContext
    {
        public const string _connectionString = "AplicationDbConnection";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
