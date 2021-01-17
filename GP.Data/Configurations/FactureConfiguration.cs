using GP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Configurations
{
    public class FactureConfiguration : EntityTypeConfiguration<Facture>
    {
        public FactureConfiguration()
        {
            //Key composed of 3 params
            HasKey(C => new
            {
                C.ClientFk,
                C.ProductFk,
                C.DateAchat
            });
            // 1..* Between Client and Facture
            HasRequired(F => F.Client)
            .WithMany(C => C.Factures)
            .HasForeignKey(F => F.ClientFk)
            .WillCascadeOnDelete(false);
            // 1..* Between Product and Facture
            HasRequired(F => F.Produit)
            .WithMany(P => P.Factures)
            .HasForeignKey(F => F.ProductFk)
            .WillCascadeOnDelete(false);
        }
    }
}
