using GP.Data.Configurations;
using GP.Data.Conventions;
using GP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data
{
    public class GPContext : DbContext
    {
        public GPContext() : base("name=GPConnect")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Conventions.Add(new DateTime2Convention());
            
            //TPT
            //modelBuilder.Entity<Chemical>().ToTable("Chemicals");
            //modelBuilder.Entity<Biological>().ToTable("Biologicals");
            //TPC
            /*modelBuilder.Entity<Biological>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Biologicals");
            });
            modelBuilder.Entity<Chemical>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Chemicals");
            });*/
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
