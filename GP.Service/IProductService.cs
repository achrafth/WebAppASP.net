using GP.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> FindMost5ExpensiveProds();
        float UnavailableProductsPercentage();
        IEnumerable<Product> GetProdsByClient(Client C);
        void DeleteOldProducts();
    }
}
