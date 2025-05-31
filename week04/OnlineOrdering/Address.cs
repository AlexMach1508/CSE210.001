using System;

namespace OnlineOrdering
{
    // The Address class encapsulates a customer's address:
    // street, city, state/province, and country. All fields are private.
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        // Constructor
        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        // Read-only properties to expose each field
        public string Street
        {
            get { return _street; }
        }

        public string City
        {
            get { return _city; }
        }

        public string StateOrProvince
        {
            get { return _stateOrProvince; }
        }

        public string Country
        {
            get { return _country; }
        }

        // Method that returns true if the country is "USA" (case-insensitive)
        public bool IsInUSA()
        {
            return _country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        // Method that returns the full address as a string with newline characters
        public string GetFormattedAddress()
        {
            // Example output:
            // 123 Main St
            // Springfield, IL
            // USA
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }
}
