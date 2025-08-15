using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public record Details
{
    private Details(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; }

    public string Description { get; }

    public static Result<Details> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.MaxLengthTitle)
            return Result.Failure<Details>("Title must not be empty or longer than 500 characters!");

        if (string.IsNullOrWhiteSpace(description) || title.Length > Constants.MaxLengthDescription)
            return Result.Failure<Details>("Description is not be empty or longer than 5000 characters!");

        var details = new Details(title, description);

        return Result.Success(details);
    }
}