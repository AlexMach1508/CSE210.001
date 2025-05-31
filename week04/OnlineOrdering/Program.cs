using System;
using System.Globalization;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------
            // Create sample addresses and customers
            // ------------------------------------------

            // Customer #1 lives in the USA
            Address address1 = new Address(
                street: "123 Maple Street",
                city:   "Springfield",
                stateOrProvince: "IL",
                country: "USA"
            );
            Customer customer1 = new Customer(name: "Alice Johnson", address: address1);

            // Customer #2 lives outside the USA
            Address address2 = new Address(
                street: "456 Elm Avenue",
                city:   "Toronto",
                stateOrProvince: "ON",
                country: "Canada"
            );
            Customer customer2 = new Customer(name: "Bob Martinez", address: address2);

            // ------------------------------------------
            // Create sample products
            // ------------------------------------------

            // Products for order #1
            Product prodA = new Product(
                name: "Wireless Mouse",
                productId: "WM-1001",
                pricePerUnit: 25.99m,
                quantity: 2
            );
            Product prodB = new Product(
                name: "USB-C Charger",
                productId: "UC-2002",
                pricePerUnit: 19.50m,
                quantity: 1
            );
            Product prodC = new Product(
                name: "Laptop Sleeve",
                productId: "LS-3003",
                pricePerUnit: 15.00m,
                quantity: 1
            );

            // Products for order #2
            Product prodD = new Product(
                name: "Bluetooth Headphones",
                productId: "BH-4004",
                pricePerUnit: 79.99m,
                quantity: 1
            );
            Product prodE = new Product(
                name: "Portable SSD 1TB",
                productId: "PS-5005",
                pricePerUnit: 129.95m,
                quantity: 1
            );
            Product prodF = new Product(
                name: "Notebook Stand",
                productId: "NS-6006",
                pricePerUnit: 34.75m,
                quantity: 2
            );

            // ------------------------------------------
            // Create orders and add products
            // ------------------------------------------

            // Order #1 for customer1
            Order order1 = new Order(customer1);
            order1.AddProduct(prodA);
            order1.AddProduct(prodB);
            order1.AddProduct(prodC);

            // Order #2 for customer2
            Order order2 = new Order(customer2);
            order2.AddProduct(prodD);
            order2.AddProduct(prodE);
            order2.AddProduct(prodF);

            // ------------------------------------------
            // Display results in the console
            // ------------------------------------------

            // Currency formatter to display prices in local format (e.g., $xx.xx)
            NumberFormatInfo nfi = CultureInfo.GetCultureInfo("en-US").NumberFormat;
            nfi = (NumberFormatInfo)nfi.Clone();
            nfi.CurrencySymbol = "$";

            // ---- Order #1 ----
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            decimal total1 = order1.CalculateTotalPrice();
            Console.WriteLine($"Total Price (including shipping): {total1.ToString("C", nfi)}");
            Console.WriteLine(new string('=', 50));

            // ---- Order #2 ----
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            decimal total2 = order2.CalculateTotalPrice();
            Console.WriteLine($"Total Price (including shipping): {total2.ToString("C", nfi)}");
            Console.WriteLine(new string('=', 50));

            // Keep the console window open until a key is pressed
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
