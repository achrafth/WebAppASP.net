using GP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public class ManageProduct
    {
        private List<Product> Products;
        public Func<string, List<Product>> FindProduct;
        public Func<string, List<Product>> FindProducts;
        public Func<Category, List<Product>> ScanProduct;
        public Func<Category, List<Product>> ScanProducts;

        public ManageProduct(List<Product> products)
        {
            this.Products = products;
            FindProduct = delegate (string C)
            {
                List<Product> ListProds = new List<Product>();
                foreach (Product p in products)
                {
                    if (p.Name.ToUpper().StartsWith(C.ToUpper()))
                    {
                        ListProds.Add(p);
                    }
                }
                return ListProds;
            };

            FindProducts = (string C) =>
            {
                List<Product> ListProds = new List<Product>();
                foreach (Product p in products)
                {
                    if (p.Name.ToUpper().StartsWith(C.ToUpper()))
                    {
                        ListProds.Add(p);
                    }
                }
                return ListProds;
            };


            ScanProduct = delegate (Category Category)
            {
                List<Product> ListProds = new List<Product>();
                foreach (Product p in products)
                {
                    if (p.Category.Equals(Category))
                    {
                        ListProds.Add(p);
                    }
                }
                return ListProds;
            };

            ScanProducts = (Category Category) =>
            {
                List<Product> ListProds = new List<Product>();
                foreach (Product p in products)
                {
                    if (p.Category.Equals(Category))
                    {
                        ListProds.Add(p);
                    }
                }
                return ListProds;
            };
        }

        public List<Product> Get5Product(double price)
        {
            var query = from P in Products
                        where P.Price > price
                        select P;
            return query.Take(5).ToList<Product>();
        }

        public List<Chemical> Get5Chemical(double price)
        {
            var query = from P in Products
                         where P.Price > price
                         && P is Chemical
                         select (Chemical) P;
            return query.Take(5).ToList<Chemical>();
            /*OR
            var query = (from P in Products
                         where P.Price > price
                         select P).OfType<Chemical>();
            return query.Take(5).ToList<Chemical>();*/
        }

        public IEnumerable<Product> GetProductPrice(double price)
        {
            var query = from P in Products
                        where P.Price > price
                        select P;
            return query.Skip(2);
        }

        public double GetAveragePrice()
        {
            var query = from P in Products
                        select P.Price;
            return query.Average();
        }

        public Product GetMaxPrice()
        {
            var queryMax = (from P in Products
                            select P.Price).Max();
            var query = from P in Products
                        where P.Price == queryMax
                        select P;
            return query.First();
        }

        public int GetCountProduct(string city)
        {
            var query = from P in Products
                        where P is Chemical
                        && ((Chemical)P).City.Equals(city)
                        select P;
            return query.Count();
        }

        public IEnumerable<Chemical> GetChemicalCity()
        {
            var query = from P in Products
                        where P is Chemical
                        orderby ((Chemical)P).City
                        select (Chemical)P;
            return query;
        }

        public void GetChemicalGroupByCity()
        {
            var query = from P in Products
                        where P is Chemical
                        orderby ((Chemical)P).City
                        group ((Chemical)P) by ((Chemical)P).City;
            foreach (var i in query)
            {
                Console.WriteLine(i.Key);
                foreach (var j in i)
                {
                    Console.WriteLine(j.Name);
                }
            }
        }
    }
}
