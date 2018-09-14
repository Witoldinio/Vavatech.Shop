using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.WebService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GetCustomers();

            Console.WriteLine("------------------");
            AddCustomer();
            Console.WriteLine("------------------");
            Console.ReadLine();
        }

        private static void GetCustomers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316");

            HttpResponseMessage result = client.GetAsync("api/Customers").Result;

            if (result.IsSuccessStatusCode)
            {
                // install package Microsoft.AspNet.WebApi.Client
                List<Customer> customers = result.Content.ReadAsAsync<List<Customer>>().Result;
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        private static void AddCustomer()
        {
            Address adres = new Address();
            adres.Street = "Kolista";
            adres.Building = "24";
            adres.Local = "22";
            adres.Zip = "54-152";
            adres.City = "Wroclaw";
            adres.District = "Dolnoslaskie";
            adres.Country = "Poland";

            Customer customer = new Customer();
            customer.Name = "testowy cutomer";
            customer.FirstName = "Witold";
            customer.LastName = "Zywica";
            customer.VatNumber = "moj nip";
            customer.Address = adres;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316");
            
            HttpResponseMessage result = client.PostAsync("api/Customers", new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json")).Result;

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine(result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
