namespace Domain.ValueObjects;

public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string House { get; private set; }

    public Address(string street, string city, string house)
    {
        this.Street = street;
        this.City = city;
        this.House = house;
    }
}