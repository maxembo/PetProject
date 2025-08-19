using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record FullName
{
    private FullName(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }
    
    public string Name { get; }
    
    public string Surname { get; }
    
    public string Patronymic { get; }

    public Result<FullName> Create(string name, string surname, string patronymic)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.MaxLengthFullname)
            return Result.Failure<FullName>("Name must not be empty or longer than 100 characters!");
        
        if (string.IsNullOrWhiteSpace(surname) || surname.Length > Constants.MaxLengthFullname)
            return Result.Failure<FullName>("Surname must not be empty or longer than 100 characters!");
        
        if (string.IsNullOrWhiteSpace(patronymic) || patronymic.Length > Constants.MaxLengthFullname)
            return Result.Failure<FullName>("Patronymic must not be empty or longer than 500 characters!");
        
        var fullname = new FullName(name, surname, patronymic);
        
        return Result.Success(fullname);
    }
}