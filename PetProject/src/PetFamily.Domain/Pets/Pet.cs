using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Pets;

public class Pet : Entity
{
    //ef core
    private Pet()
    { }

    //TODO доделать богатую модель Pet
    private Pet(
        Guid id,
        string name,
        SpeciesBreed speciesBreed,
        string description,
        string color,
        HealthInformation healthInformation,
        Address address,
        PhoneNumber phoneNumber,
        DateTime birthday,
        Details details,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Species = speciesBreed;
        Description = description;
        Color = color;
        HealthInformation = healthInformation;
        Address = address;
        PhoneNumber = phoneNumber;
        Birthday = birthday;
        Details = details;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public SpeciesBreed Species { get; private set; }

    public string Description { get; private set; }

    public string Breed { get; private set; }

    public string Color { get; private set; }

    public HealthInformation HealthInformation { get; private set; }

    public Address Address { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public DateTime Birthday { get; private set; }

    public StatusHelp StatusHelp { get; private set; } = StatusHelp.NeedsHelp;

    public Details Details { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private static Result<Pet> Create(
        Guid id,
        string name,
        SpeciesBreed speciesBreed,
        string description,
        string color,
        HealthInformation healthInformation,
        Address address,
        PhoneNumber phoneNumber,
        DateTime birthday,
        Details details,
        DateTime createdAt)
    {
        id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.MaxLengthTitle)
            return Result.Failure<Pet>("Title must not be empty or longer than 500 characters!");

        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.MaxLengthDescription)
            return Result.Failure<Pet>("Description must not be empty or longer than 5000 characters!");

        if (string.IsNullOrWhiteSpace(color) || color.Length > Constants.MaxLengthColor)
            return Result.Failure<Pet>("Color must not be empty or longer than 50 characters!");

        var pet = new Pet(id, name, speciesBreed, description, color, healthInformation, address, phoneNumber, birthday,
            details, createdAt);

        return Result.Success(pet);
    }
}