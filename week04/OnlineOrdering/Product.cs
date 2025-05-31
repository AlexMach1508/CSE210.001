using System;

namespace OnlineOrdering
{
    // The Product class encapsulates the product name, ID, unit price, and quantity.
    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _pricePerUnit;
        private int _quantity;

        // Constructor
        public Product(string name, string productId, decimal pricePerUnit, int quantity)
        {
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity;
        }

        // Read-only properties for each field
        public string Name
        {
            get { return _name; }
        }

        public string ProductId
        {
            get { return _productId; }
        }

        public decimal PricePerUnit
        {
            get { return _pricePerUnit; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        // Method that calculates and returns the total cost of this product
        public decimal GetTotalCost()
        {
            // Unit price × quantity
            return _pricePerUnit * _quantity;
        }
    }
}
