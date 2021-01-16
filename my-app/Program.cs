using System;
using GP.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_app
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hi Achraf!");
            //Console.ReadKey(); //Make the console lasts
            Category C1 = new Category() { Name = "CAT1", CategoryId = 1 };
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
            PROV5.GetProducts("ProductId", "6");/*
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
            System.Console.WriteLine(P3.IsApproved);*/
            System.Console.ReadKey();
        }
    }
}
