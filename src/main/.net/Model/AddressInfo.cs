namespace ShoppingApp
{
    public sealed class AddressInfo
    {
        public string Street { get; }
        public int Apartment { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string PhoneNumber { get; }

        public AddressInfo(string street, int apartment, string city, string postalCode, string phoneNumber)
        {
            Street = street;
            Apartment = apartment;
            City = city;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
        }

        // TODO: Add operations
        //
        // void ChangeAddress(...) { }
        //
        // void ChangePhoneNumber(...) { }
    }
}