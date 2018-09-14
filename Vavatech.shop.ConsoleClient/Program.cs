using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vavatech.Shop.DbServices;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Initialize();

            ICustomersService customerService = MyServiceProvider.GetServiceProvider().GetService<ICustomersService>();
            foreach (Customer customer in customerService.Get())
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("-------------------------------------------------------");
            List<Customer> foundCustomers = customerService.SearchByCountry("Poland");
            foreach (Customer customer in foundCustomers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("-------------------------------------------------------");

            //GenerateItems();

            //ICustomersService fakeCustomerService = new FakeCustomerService();
            //List<Customer> customers = fakeCustomerService.Get();
            //
            //foreach (Customer customer in customers)
            //{
            //    customerService.Add(customer);
            //}
            // FakeApproach();
        }

        private static void GenerateItems()
        {
            IItemsService itemService = MyServiceProvider.GetServiceProvider().GetService<IItemsService>();

            Faker<Product> fakerProduct = new Faker<Product>()
                .StrictMode(true)
                .Ignore(p => p.Id)
                .RuleFor(p => p.Name, r => r.Commerce.ProductName())
                .RuleFor(p => p.Color, r => r.Commerce.Color())
                .RuleFor(p => p.Price, r => r.Finance.Amount())
                .RuleFor(p => p.EAN, r => r.Finance.Iban());

            Faker<Service> fakerService = new Faker<Service>()
                .StrictMode(true)
                .Ignore(s => s.Id)
                .RuleFor(s => s.Name, r => r.Commerce.ProductName())
                .RuleFor(s => s.Price, r => r.Finance.Amount())
                .RuleFor(s => s.EAN, r => r.Finance.Iban());

            List<Item> items = new List<Item>();
            Random random = new Random();
            for (int i = 0; i < 200; i++)
            {
                if (0 == random.Next(0, 100) % 2)
                {
                    items.Add(fakerProduct.Generate());
                }
                else
                {
                    items.Add(fakerService.Generate());
                }
            }

            ShopContext context = MyServiceProvider.GetServiceProvider().GetService<ShopContext>();
            context.Items.AddRange(items);
            context.SaveChanges();
        }

        private static void Initialize()
        {
            //install package Microsoft.Extensions.Configuration
            //install package Microsoft.Extensions.Configuration.FileExtensions
            //install package Microsoft.Extensions.Configuration.Json
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("DbSettings.json", optional: true, reloadOnChange: true);

            // plik json nie jest kopiowany do katalogu z programem wiec trzeba wejsc prawym properties
            // copy always

            IConfigurationRoot configuration = builder.Build();

            //install package Microsoft.Extensions.DependencyInjection
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<ICustomersService, DbCustomerService>();
            services.AddSingleton<IItemsService, DbItemService>();
            // install package Microsoft.Extensions.Logging.Console
            // services.AddSingleton<>
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(configuration.GetConnectionString("ShopConnection")));
        
            MyServiceProvider.RegisterServiceProvider(services.BuildServiceProvider());
        }

        private static void FakeApproach()
        {
            ICustomersService customerService = new FakeCustomerService();
            IItemsService itemService = new FakeItemService();
            IOrdersService orderService = new FakeOrderService();

            Console.WriteLine("---------------------------------");
            List<Customer> cs = customerService.SearchByCountry("Poland");
            foreach (Customer c in cs)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("---------------------------------");

            Customer customer = GetFoundCustomer(customerService);
            if (null != customer)
            {
                Order order = Order.Create(customer);

                Item item;
                do
                {
                    item = GetItem(itemService);
                    if (null != item)
                    {
                        int quantity = GetQuantity();
                        OrderItem orderItem = new OrderItem(item, quantity);

                        order.AddItem(orderItem);
                    }

                } while (null != item);

                orderService.Add(order);
            }

            List<Order> orders = orderService.Get();
            foreach (Order order in orders)
            {
                Console.WriteLine(order);
            }

            Send send = SendSMS;
            send += SendEmail;
            send += SendTwitter;
            send.Invoke("aaaaaaa");
        }

        static void SendSMS(string message)
        {
            Console.WriteLine($"SMS {message}");
        }

        static void SendEmail(string message)
        {
            Console.WriteLine($"EMAIL {message}");
        }

        static void SendTwitter(string message)
        {
            Console.WriteLine($"TWITTER {message}");
        }
        
        public delegate void Send(string message);

        private static int GetQuantity()
        {
            Console.Write("Podaj Ilość: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                return quantity;
            }

            throw new Exception("Niepoprawna wartość.");
        }

        private static Item GetItem(IItemsService itemService)
        {
            Console.Write("Podaj EAN: ");
            string query = Console.ReadLine();
            List<Item> items = itemService.Search(query);
            if (items.Any())
            {
                foreach (Item item in items)
                {
                    Console.WriteLine($"{items.IndexOf(item) + 1} \t- {item}");
                }

                Console.WriteLine("Podaj item: ");
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    return items[index - 1];
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe dane.");
                }
            }
            else
            {
                Console.WriteLine("Brak wyników.");
            }

            return null;
        }

        private static Customer GetFoundCustomer(ICustomersService customerService)
        {
            Console.Write("Podaj NIP: ");
            string query = Console.ReadLine();
            List<Customer> foundCustomers = customerService.Search(query);
            if (foundCustomers.Any())
            {
                foreach (Customer customer in foundCustomers)
                {
                    Console.WriteLine($"{foundCustomers.IndexOf(customer) + 1} \t- {customer}");
                }

                Console.Write("Podaj klienta: ");
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    return foundCustomers[index - 1];
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe dane.");
                }
            }
            else
            {
                Console.WriteLine("Brak wyników.");
            }

            return null;
        }

        private static void GetProductsFromItemsTest(List<Item> items)
        {
            Console.WriteLine("Only products:");
            List<Product> products = items.OfType<Product>().ToList();
            foreach (Item item in products)
            {
                Console.WriteLine(item);
            }
        }

        private static IItemsService GetItemsTest()
        {
            return new FakeItemService();
        }

        private static ICustomersService GetCustomersTest()
        {
            ICustomersService customerService = new FakeCustomerService();
            List<Customer> customers = customerService.Get();

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }

            return customerService;
        }
    }
}
