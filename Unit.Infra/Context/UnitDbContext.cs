

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Unit.Core.Entities;

namespace Unit.Infra.Context
{
    public class UnitDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public string? DbPath { get; set; }

        public UnitDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "unit.db");
        }

        public UnitDbContext(DbContextOptions<UnitDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }
    }
}