using System;

namespace OnlineOrdering
{
    // The Customer class encapsulates the customer's name and Address.
    public class Customer
    {
        private string _name;
        private Address _address; // Address as another object

        // Constructor
        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        // Read-only property for the name
        public string Name
        {
            get { return _name; }
        }

        // Read-only property to access the Address
        public Address Address
        {
            get { return _address; }
        }

        // Method that returns whether the customer lives in the USA (delegates to Address)
        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }
    }
}
