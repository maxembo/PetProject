using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Breed
{
    // ef core
    private Breed() 
    { }

    private Breed(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
    
    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public static Result<Breed> Create(Guid id, string title)
    {
        if(string.IsNullOrWhiteSpace(title) || title.Length > Constants.MaxLengthTitle)
            return Result.Failure<Breed>("Title must not be empty or longer than 500 characters!");
        
        var breed = new Breed(id, title);
        
        return Result.Success(breed);
    }
}