using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Provider : Concept
    {
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        private string password;
        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value != password)
                    System.Console.WriteLine("Incorrect Password!!");
                else
                {
                    confirmPassword = value;
                    System.Console.WriteLine("Correct Password!");
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20)
                    password = value;
                else
                    System.Console.WriteLine("Password must contains between 5 and 20 characters!");
            }
        }
        public string UserName { get; set; }
        public List<Product> Products { get; set; }
        public static void SetIsApproved(Provider P)
        {
            P.IsApproved = string.Compare(P.Password, P.ConfirmPassword) == 0;
        }
        public static void SetIsApproved(string password, string confirmPassword, bool isApproved)
        {
            isApproved = string.Compare(password, confirmPassword) == 0;
        }
        public Provider()
        {
        }

        public Provider(string confirmPassword, DateTime dateCreated, string email, int id, bool isApproved, string password, string userName)
        {
            ConfirmPassword = confirmPassword;
            DateCreated = dateCreated;
            Email = email;
            Id = id;
            IsApproved = isApproved;
            Password = password;
            UserName = userName;
        }
        public bool Login0(string username, string password)
        {
            return string.Compare(UserName, username) == 0
            && string.Compare(Password, password) == 0;
        }

        public bool Login1(string username, string password, string email)
        {
            return string.Compare(UserName, username) == 0
                && string.Compare(Password, password) == 0
                && string.Compare(Email, email) == 0;
        }

        public bool Login2(string username, string password, string email)
        {
            return string.Compare(UserName, username) == 0
                && string.Compare(password, Password) == 0
                && email != null ? string.Compare(Email, email) == 0 : true;
        }

        public void GetProducts(string filterType, string filterValue)
        {
            if (Products != null)
            {
                switch (filterType)
                {
                    case "Name":
                        foreach (Product P in Products)
                        {

                            if (string.Equals(P.Name, filterValue))
                            {
                                P.GetDetails();
                            }

                        }
                        break;
                    case "DateProd":
                        foreach (Product p in Products)
                        {

                            if (DateTime.Equals(p.DateProd,
                                DateTime.Parse(filterValue)))
                            {
                                p.GetDetails();
                            }

                        }
                        break;
                    case "Price":
                        foreach (Product P in Products)
                        {

                            if (P.Price == double.Parse(filterValue))
                            {
                                P.GetDetails();
                            }

                        }
                        break;
                    case "ProductId":
                        foreach (Product P in Products)
                        {

                            if (P.ProductId == int.Parse(filterValue))
                            {
                                P.GetDetails();
                            }

                        }
                        break;
                    case "Quantity":
                        foreach (Product P in Products)
                        {

                            if (P.Quantity == int.Parse(filterValue))
                            {
                                P.GetDetails();
                            }

                        }
                        break;
                    case "Description":
                        foreach (Product P in Products)
                        {

                            if (string.Equals(P.Description, filterValue))
                            {
                                P.GetDetails();
                            }

                        }
                        break;

                }
            }

        }
        public override void GetDetails()
        {
            System.Console.WriteLine("Id: " + Id + " Email: " + Email + " UserName: " + UserName);
            if (Products != null)
            {
                foreach (Product P in Products)
                {
                    P.GetDetails();
                    P.GetMyType();
                }
            }
        }
    }
}
