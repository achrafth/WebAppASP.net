using System;
using GP.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Service;
using GP.Data;

namespace my_app
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hi Achraf!");
            //Console.ReadKey(); //Make the console lasts
            /*Category C1 = new Category() { Name = "CAT1", CategoryId = 1 };
            Category C2 = new Category() { Name = "CAT2", CategoryId = 2 };
            Category C3 = new Category() { Name = "CAT3", CategoryId = 3 };

            Product Pr1 = new Product()
            {
                ProductId = 1,
                Name = "PROD1",
                DateProd = DateTime.Now,
                Price = 10,
                Quantity = 10,
                Category = C1
            };
            Product Pr2 = new Product()
            {
                ProductId = 2,
                Name = "PROD2",
                DateProd = DateTime.Now,
                Price = 20,
                Quantity = 20,
                Category = C1
            };
            Product Pr3 = new Product()
            {
                ProductId = 3,
                Name = "PROD3",
                DateProd = DateTime.Now,
                Price = 30,
                Quantity = 30,
                Category = C3
            };
            Product Pr4 = new Product()
            {
                ProductId = 4,
                Name = "PROD4",
                DateProd = DateTime.Now,
                Price = 40,
                Quantity = 40,
            };
            Product Pr5 = new Product()
            {
                ProductId = 5,
                Name = "PROD5",
                DateProd = DateTime.Now,
                Price = 50,
                Quantity = 50,
                Category = C2
            };
            Product Pr6 = new Product()
            {
                ProductId = 6,
                Name = "PROD6",
                DateProd = DateTime.Now,
                Price = 60,
                Quantity = 60,
                Category = C3
            };

            Chemical Ch = new Chemical()
            {
                LabName = "CCC",
                City = "Ariana",
                StreetAddress = "El Ghazela",
                ProductId = 10,
                DateProd = DateTime.Now,
                Price = 10,
                Quantity = 10,
                Category = C2
            };
            Biological B = new Biological()
            {
                Herbs = "BBB",
                ProductId = 20,
                DateProd = DateTime.Now,
                Price = 20,
                Quantity = 20,
                Category = C2
            };

            Provider PROV1 = new Provider()
            {
                Password = "1234567",
                ConfirmPassword = "1234567"
            };

            Provider PROV2 = new Provider("123456", DateTime.Now,
                "Ach.Thamri@gmail.com",
                2, false, "1234567", "Provider 2");
            PROV2.Products = new List<Product>() { Pr1, Pr5 };
            Provider PROV3 = new Provider()
            {
                Id = 3,
                Password = "123450",
                ConfirmPassword = "1234500"
            };
            PROV3.Products = new List<Product>() { Pr1, Pr4 };
            Provider PROV4 = new Provider()
            {
                Id = 4,
                Password = "1234500",
                ConfirmPassword = "1234500"
            };
            PROV4.Products = new List<Product>() { Pr6, Pr4 };
            Provider PROV5 = new Provider()
            {
                Id = 5,
                Password = "12345000",
                ConfirmPassword = "12345000"
            };
            PROV5.Products = new List<Product>() { Pr6, Pr4 };

            System.Console.WriteLine("///////////////////////////////////////////////////////////////");
            System.Console.WriteLine("IsApproved Initial Value: " + PROV1.IsApproved);
            PROV1.Products = new List<Product>() { Pr1, Pr2, Pr3 };
            System.Console.WriteLine("1/ Section With Value:");
            Provider.SetIsApproved(PROV1.Password, PROV1.ConfirmPassword, PROV1.IsApproved);
            if (PROV1.IsApproved == false)
            {
                System.Console.WriteLine("Password Confirmed for the 1st Provider!");
            }
            else System.Console.WriteLine("Password Not Confirmed for the 1st Provider!");

            System.Console.WriteLine("///////////////////////////////////////////////////////////////");
            System.Console.WriteLine("2/ Section With Reference:");
            Provider.SetIsApproved(PROV3);
            if (PROV3.IsApproved)
            {
                System.Console.WriteLine("Password Confirmed for the 3rd Provider!");
            }
            else System.Console.WriteLine("Password Not Confirmed for the 3rd Provider!");

            System.Console.WriteLine("///////////////////////////////////////////////////////////////");
            System.Console.WriteLine("--- Test de Login pour le Provider 2 ---");
            if (PROV2.Login2("Provider 2", "1234567", "Achh.Thamri@gmail.com"))
            {
                System.Console.WriteLine("Satisfied Authentification!");
            }
            else System.Console.WriteLine("Error Authentification!");

            System.Console.WriteLine("///////////////////////////////////////////////////////////////");
            System.Console.WriteLine("--- Display providers' details with Products & Categories ---");
            System.Console.WriteLine("Details of 1st Provider: ");
            PROV1.GetDetails();
            System.Console.WriteLine("Details of 2nd Provider: ");
            PROV2.GetDetails();

            System.Console.WriteLine("///////////////////////////////////////////////////////////////");
            System.Console.WriteLine("--- Display details of products TYPE 'Biological' & 'Chemical' ---");
            Ch.GetDetails();
            Ch.GetMyType();
            B.GetDetails();
            B.GetMyType();

            System.Console.WriteLine("///////////////////////////////////////////////////////////////");
            System.Console.WriteLine("--- Custom display with ProductId of Provider 3 & 5 ---");
            PROV3.GetProducts("ProductId", "4");
            PROV5.GetProducts("ProductId", "6");
            ------------------------------------------
            //With Value
            Provider P1 = new Provider();
            P1.Password = "123456";
            P1.ConfirmPassword = "123456";
            Provider.SetIsApproved(P1);
            System.Console.WriteLine(P1.Password);
            System.Console.WriteLine(P1.ConfirmPassword);
            System.Console.WriteLine(P1.IsApproved);
            System.Console.ReadKey();

            ------------------------------------------
            //Init Object
            Provider P2 = new Provider()
            {
                Password = "12345678",
                ConfirmPassword = "1234567"
            }
            Provider.SetIsApproved(P2.Password, P2.ConfirmPassword, P2.IsApproved);
            System.Console.WriteLine("Password: " + P2.Password);
            System.Console.WriteLine(P2.IsApproved);

            ------------------------------------------
            //With Reference
            Provider P3 = new Provider("123456", DateTime.Now, "Provider@gmail.com", 2, true, "1234567", "Provider 3");
            System.Console.WriteLine("Initial Value: " + P3.IsApproved);
            Provider.SetIsApproved(P3);
            System.Console.WriteLine("Password: " + P3.Password);
            System.Console.WriteLine(P3.IsApproved);
            Category Fruit = new Category()
            { Name = "Fruit" };
            Category Alimentaire = new Category()
            { Name = "Alimentaire" };

            Product AcideCitrique = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Acide Citrique",
                Description = "Monohydrate-E330-USP32",
                Category = Alimentaire,
                Price = 90,
                Quantity = 30,
                City = "Sousse"
            };
            Product CacaoNaturelle = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Poudre de Cacao Naturelle",
                Description = "10% - 12%",
                Category = Alimentaire,
                Price = 419,
                Quantity = 80,
                City = "Sfax"
            };
            Product CacoaAlcalinisee = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Poudre de Cacao Alcalinisée",
                Description = "10% - 12%",
                Category = Alimentaire,
                Price = 7,
                Quantity = 300,
                City = "Sfax"
            };
            Product Dioxyde = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Dioxyde De Titane",
                Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique",
                Category = Alimentaire,
                Price = 200,
                Quantity = 50,
                City = "Tunis"
            };
            Product Amidon = new Chemical()
            {
                Name = "Amidon De Maïs",
                Description = "Amidon de maïs natif",
                Category = Alimentaire,
                Price = 70,
                Quantity = 30,
                City = "Tunis"
            };
            Product BlackBerry = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = "BlackBerry",
                Category = Fruit,
                Name = "BlackBerry",
                Price = 60,
                ProductId = 0,
                Quantity = 0
            };
            Product Apple = new Biological()
            {
                Description = "",
                Category = Fruit,
                DateProd = new DateTime(2000, 12, 12),
                Name = "Apple",
                Price = 100.00,
                ProductId = 0,
                Quantity = 100
            };

            List<Product> products = new List<Product>
            { Dioxyde, Amidon, CacoaAlcalinisee, BlackBerry, Apple, AcideCitrique, CacaoNaturelle};

            ManageProduct manageProduct = new ManageProduct(products);

            Provider Salter = new Provider()
            {
                Id = 1,
                UserName = "SALTER"
            };
            Provider SubMedical = new Provider()
            {
                Id = 2,
                UserName = "SUBMEDICAL"
            };
            Provider PalliserSA = new Provider()
            {
                Id = 3,
                UserName = "PALLISERSA"
            };
            Provider Prov4 = new Provider()
            {
                Id = 4,
                UserName = "PROV4"
            };
            Provider Prov5 = new Provider()
            {
                Id = 5,
                UserName = "PROV5"
            };

            List<Provider> providers = new List<Provider>
            {Salter, SubMedical, PalliserSA, Prov4, Prov5};

            ManageProvider manageProvider = new ManageProvider(providers);

            System.Console.WriteLine("Return a list of providers under the Name SUBMEDICAL:");
            List<Provider> Pv0 = manageProvider.GetProviderByName("SUBMEDICAL");
            foreach (var i in Pv0)
            {
                i.GetDetails();
            }

            System.Console.WriteLine("Return the first provider under the Name SALTER: ");
            Provider Pv1 = manageProvider.GetFirstProviderByName("SALTER");
            Pv1.GetDetails();

            System.Console.WriteLine("Return the provider relative to the Id 5: ");
            Provider Pv2 = manageProvider.GetProviderById(5);
            Pv2.GetDetails();

            System.Console.WriteLine("Return the first 5 Chemical products whose Price's higher than 10: ");
            List<Chemical> Pr0 = manageProduct.Get5Chemical(10);
            foreach (var i in Pr0)
            {
                i.GetDetails();
            }

            System.Console.WriteLine("Return a list of products where the Price is higher than 10, skipping the first 2: ");
            IEnumerable<Product> Pr1 = manageProduct.GetProductPrice(10);
            foreach (var i in Pr1)
            {
                i.GetDetails();
            }

            System.Console.WriteLine("Return the average Price of all products: ");
            double A = manageProduct.GetAveragePrice();
            System.Console.WriteLine(A);

            System.Console.WriteLine("Return the highest Price of all products: ");
            Product Pr2 = manageProduct.GetMaxPrice();
            Pr2.GetDetails();

            System.Console.WriteLine("Return the number of Chemical products of Tunis City: ");
            int B = manageProduct.GetCountProduct("Tunis");
            System.Console.WriteLine(B);

            System.Console.WriteLine("Return a list of Chemical products ordered by City: ");
            IEnumerable<Chemical> Ch0 = manageProduct.GetChemicalCity();
            foreach (var i in Ch0)
            {
                i.GetDetails();
            }
            System.Console.WriteLine("Return a list of Chemical products ordered and grouped by City: ");
            manageProduct.GetChemicalGroupByCity();

            System.Console.WriteLine("--- ANONYMOUS Methods ---");
            System.Console.WriteLine("Return a list of products where their names start with A: ");
            List<Product> Pr3 = manageProduct.FindProduct("A");
            foreach (var p in Pr3)
            {
                p.GetDetails();
            }

            System.Console.WriteLine("Return a list of products that belong to the Category Fruit: ");
            List<Product> Pr4 = manageProduct.ScanProduct(Fruit);
            foreach (var p in Pr4)
            {
                p.GetDetails();
            }

            System.Console.WriteLine("--- LAMBDA Expressions ---");
            System.Console.WriteLine("Return a list of products where their names start with A: ");
            List<Product> Pr5 = manageProduct.FindProducts("A");
            foreach (var p in Pr5)
            {
                p.GetDetails();
            }

            System.Console.WriteLine("Return a list of products that belong to the Category Fruit: ");
            List<Product> Pr6 = manageProduct.ScanProducts(Fruit);
            foreach (var p in Pr6)
            {
                p.GetDetails();
            }

            System.Console.WriteLine("--- EXTENSION Methods --");
            System.Console.WriteLine("Put in capitals the Name of the Product Apple: ");
            manageProduct.UpperName(Apple);
            Apple.GetDetails();
            System.Console.WriteLine("Return True if the Product Apple belongs to the Category Fruit: ");
            System.Console.WriteLine(manageProduct.InCategory(Fruit, Apple));
            System.Console.ReadKey();
            GPContext X = new GPContext();
            Provider Sater = new Provider()
            {
                Id = 1,
                DateCreated = new DateTime(2020, 10, 24),
                UserName = "SALTER"
            };
            X.Providers.Add(Sater);
            X.SaveChanges();
            System.Console.WriteLine("DATABASE CREATED!");*/
            System.Console.ReadKey();
        }
    }
}
