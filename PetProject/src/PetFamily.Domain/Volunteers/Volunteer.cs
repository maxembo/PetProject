using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;

namespace PetFamily.Domain.Volunteers;

public sealed class Volunteer : Entity<Guid>
{
    //ef core
    private Volunteer(Guid id) : base(id)
    { }

    private readonly List<Pet> _pets = new List<Pet>();
    private readonly List<SocialNetwork> _socialNetworks = new List<SocialNetwork>();
    private readonly List<Details> _details = new List<Details>();

    public IReadOnlyList<Pet> Pets => _pets.AsReadOnly();
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks.AsReadOnly();
    public IReadOnlyList<Details> Details => _details.AsReadOnly();
    public FullName FullName { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public string Description { get; private set; }
    public int YearsOfExperience { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    private Volunteer(
        FullName fullName,
        EmailAddress emailAddress,
        string description,
        int yearsOfExperience,
        PhoneNumber phoneNumber)
    {
        FullName = fullName;
        EmailAddress = emailAddress;
        Description = description;
        YearsOfExperience = yearsOfExperience;
        PhoneNumber = phoneNumber;
    }

    public static Result<Volunteer> Create(
        FullName fullName,
        EmailAddress emailAddress,
        string description,
        int yearsOfExperience,
        PhoneNumber phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.MaxLengthDescription)
            return Result.Failure<Volunteer>("Description must not be empty or longer than 5000 characters!");

        if (yearsOfExperience < 0 || yearsOfExperience > Constants.MaxLengthYearsOfExperience)
            return Result.Failure<Volunteer>("Year must not be empty or longer than 100 characters!");

        var volunteer = new Volunteer(fullName, emailAddress, description, yearsOfExperience, phoneNumber);

        return Result.Success(volunteer);
    }

    public Result AddPet(Pet pet)
    {
        if (_pets.Contains(pet))
            return Result.Failure("Pet already exists!");

        _pets.Add(pet);

        return Result.Success();
    }

    public Result RemovePet(Pet pet)
    {
        if (!_pets.Contains(pet))
            return Result.Failure("Pet not found!");

        _pets.Remove(pet);

        return Result.Success();
    }

    public Result AddSocialNetwork(SocialNetwork socialNetwork)
    {
        if (_socialNetworks.Contains(socialNetwork))
            return Result.Failure("SocialNetwork already exists!");

        _socialNetworks.Add(socialNetwork);

        return Result.Success();
    }

    public Result RemoveSocialNetwork(SocialNetwork socialNetwork)
    {
        if (!_socialNetworks.Contains(socialNetwork))
            return Result.Failure("SocialNetwork not found!");

        _socialNetworks.Remove(socialNetwork);

        return Result.Success();
    }

    public Result AddDetails(Details details)
    {
        if (_details.Contains(details))
            return Result.Failure("Detail already exists!");

        _details.Add(details);

        return Result.Success();
    }

    public Result RemoveDetails(Details details)
    {
        if (!_details.Contains(details))
            return Result.Failure("Detail not found!");

        _details.Remove(details);

        return Result.Success();
    }
    
    public int CountPetsWith(StatusHelp status) => _pets.Count(pet => pet.StatusHelp == status);
}