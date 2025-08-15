using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record SocialNetwork
{
    private SocialNetwork(string link, string title)
    {
        Link = link;
        Title = title;
    }
    
    public string Link { get;  }
    
    public string Title { get; }

    public static Result<SocialNetwork> Create(string link, string title)
    {
        if(string.IsNullOrWhiteSpace(link) || link.Length > Constants.MaxLengthLink)
            return Result.Failure<SocialNetwork>("Link must not be empty or longer than 100 characters!");
        
        if(string.IsNullOrWhiteSpace(title) || title.Length > Constants.MaxLengthTitle)
            return Result.Failure<SocialNetwork>("Title must not be empty or longer than 500 characters!");

        var socialNetwork = new SocialNetwork(link, title);
        
        return Result.Success(socialNetwork);
    }
}