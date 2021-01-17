using GP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        { //Many to Many configuration
            HasMany(Pc => Pc.Providers)
            .WithMany(Pr => Pr.Products)
            .Map(M =>
            {
                M.ToTable("Providings"); //Table of association
                M.MapLeftKey("Product");
                M.MapRightKey("Provider");
            });
            //One To Many if you need 0..* use HasOptional()
            HasRequired(Pc => Pc.MyCategory)
            .WithMany(C => C.Products)
            .HasForeignKey(Pc => Pc.CategoryId)
            .WillCascadeOnDelete(false);
            //TPH
            Map<Biological>(B => B.Requires("isBiological").HasValue(1));
            Map<Chemical>(Ch => Ch.Requires("isBiological").HasValue(0));
        }
    }
}
