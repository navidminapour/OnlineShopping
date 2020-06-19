using Framework.Domain;
using System;

namespace Shipping.Domain.Model
{
    public class Address : ValueObjectBase
    {
        public string Country { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public int Number { get; protected set; }
        public int Unit { get; protected set; }
        public string ZipCode { get; protected set; }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }

        protected Address()
        {

        }

        public Address(string country, string city, string street, int number, int unit, string zipCode,
    double latitude, double longitude)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
            Unit = unit;
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
