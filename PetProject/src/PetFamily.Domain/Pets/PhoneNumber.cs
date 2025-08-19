using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public record PhoneNumber
{
    private const string Pattern = @"^(\+7|8)\d{10}$";

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public string Number { get; }

    public static Result<PhoneNumber> Create(string number)
    {
        if (string.IsNullOrWhiteSpace(number) || Regex.IsMatch(number, Pattern))
            return Result.Failure<PhoneNumber>("Invalid phone number");

        var phoneNumber = new PhoneNumber(number);

        return Result.Success(phoneNumber);
    }
}