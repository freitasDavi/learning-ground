

using Microsoft.EntityFrameworkCore;
using Unit.Core.Entities;

namespace Unit.Infra.Context
{
    public class UnitDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public string DbPath { get; set; }

        public UnitDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "unit.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}