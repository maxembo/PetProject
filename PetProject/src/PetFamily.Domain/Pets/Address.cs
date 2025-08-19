using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public record Address
{
    private Address(string country, string city, string street, string house)
    {
        Country = country;
        City = city;
        Street = street;
        House = house;
    }

    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string House { get; }

    public static Result<Address> Create(string country, string city, string street, string house)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<Address>("Country must not be empty!");

        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City must not be empty!");

        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street must not be empty!");

        if (string.IsNullOrWhiteSpace(house))
            return Result.Failure<Address>("House must not be empty!");

        var address = new Address(country, city, street, house);

        return Result.Success(address);
    }
}