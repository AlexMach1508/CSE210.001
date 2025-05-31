using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    // The Order class encapsulates a list of products and a customer.
    // It can calculate the total cost, generate a packing label, and generate a shipping label.
    public class Order
    {
        private List<Product> _products;  // Internal list of products
        private Customer _customer;       // Customer who placed the order

        // Constructor initializes the list and assigns the customer
        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        // Method to add a product to this order
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                _products.Add(product);
            }
        }

        // Method that calculates the total price of the order
        public decimal CalculateTotalPrice()
        {
            decimal subtotal = 0m;

            // Sum the total cost of each product
            foreach (Product prod in _products)
            {
                subtotal += prod.GetTotalCost();
            }

            // Add a one-time shipping cost:
            // $5 if the customer is in the USA, $35 if outside the USA
            decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;

            return subtotal + shippingCost;
        }

        // Method that generates the packing label:
        // lists the name and product ID of each product
        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== Packing Label ===");
            foreach (Product prod in _products)
            {
                sb.AppendLine($"Product: {prod.Name} (ID: {prod.ProductId})");
            }
            return sb.ToString();
        }

        // Method that generates the shipping label:
        // includes the customer's name and formatted address
        public string GetShippingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== Shipping Label ===");
            sb.AppendLine(_customer.Name);
            sb.AppendLine(_customer.Address.GetFormattedAddress());
            return sb.ToString();
        }
    }
}
