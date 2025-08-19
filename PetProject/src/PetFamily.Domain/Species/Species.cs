using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public sealed class Species : Entity<Guid>
{
    private readonly List<Breed> _breeds = new List<Breed>();

    //ef core 
    private Species(Guid id) : base(id)
    { }
    
    private Species(Guid id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }
    public IReadOnlyList<Breed> Breeds => _breeds;
    
    public static Result<Species> Create(Guid id, string title)
    {
        if(string.IsNullOrWhiteSpace(title) || title.Length > Constants.MaxLengthTitle)
            return Result.Failure<Species>("Title must not be empty or longer than 500 characters!");
        
        var species = new Species(id, title);

        return Result.Success(species);
    }

    public Result AddBreed(Breed breed)
    {
        if(_breeds.Contains(breed))
            return Result.Failure("Breed is already added");
        
        _breeds.Add(breed);
        
        return Result.Success();
    }

    public Result RemoveBreed(Breed breed)
    {
        if(!_breeds.Remove(breed))
            return Result.Failure("Breed not found");
        
        return Result.Success();
    }
}