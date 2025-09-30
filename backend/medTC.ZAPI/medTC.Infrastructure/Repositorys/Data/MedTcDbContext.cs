using medTC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medTC.Infrastructure.Repositorys.Data
{
    public class MedTcDbContext : DbContext
    {
        public MedTcDbContext(DbContextOptions<MedTcDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity => 
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.Id);
                //entity.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
                //entity.Property(p => p.Description).HasColumnType("varchar(200)");
            });
        }
    }
}
