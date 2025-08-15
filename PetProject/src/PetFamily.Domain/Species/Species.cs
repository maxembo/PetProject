using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Species
{
    private readonly List<Breed> _breeds = [];

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public IReadOnlyList<Breed> Breeds => _breeds;
    
    public Species(Guid id, string title, List<Breed> breeds)
    {
        Id = id;
        Title = title;
    }

    public static Result<Species> Create(Guid id, string title, List<Breed> breed)
    {
        var species = new Species(id, title, breed);

        return Result.Success(species);
    }

    public Result AddBreed(Breed breed)
    {
        if (_breeds is null)
            return Result.Failure("Breeds list is empty");
        
        if(_breeds.Contains(breed))
            return Result.Failure("Breed is already added");
        
        _breeds.Add(breed);
        
        return Result.Success();
    }

    public Result RemoveBreed(Breed breed)
    {
        if(_breeds is null)
            return Result.Failure("Breeds list is empty");
        
        _breeds.Remove(breed);
        
        return Result.Success();
    }
}