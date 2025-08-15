using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record EmailAddress
{
    private const string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    
    private EmailAddress(string email) => Email = email;

    public string Email { get; }

    public static Result<EmailAddress> Create(string email)
    {
        if(string.IsNullOrWhiteSpace(email) || Regex.IsMatch(email, Pattern))
            return Result.Failure<EmailAddress>("Invalid email address");

        var emailResult = new EmailAddress(email);
        
        return Result.Success<EmailAddress>(emailResult);
    }
}