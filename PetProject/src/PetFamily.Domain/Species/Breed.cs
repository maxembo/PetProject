using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public sealed class Breed : Entity<Guid>
{
    // ef core
    private Breed(Guid id) : base(id) 
    { }

    private Breed(Guid id, string title) : base(id)
    {
        Id = id;
        Title = title;
    }
    
    public string Title { get; private set; }

    public static Result<Breed> Create(Guid id, string title)
    {
        if(string.IsNullOrWhiteSpace(title) || title.Length > Constants.MaxLengthTitle)
            return Result.Failure<Breed>("Title must not be empty or longer than 500 characters!");
        
        var breed = new Breed(id, title);
        
        return Result.Success(breed);
    }
}