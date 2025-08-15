using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public record HealthInformation 
{
    private HealthInformation(float width, float height, bool isVaccinated, bool isNeutered)
    {
        Weight = width;
        Height = height;
        IsNeutered = isNeutered;
        IsVaccinated = isVaccinated;
    }
    
    public float Weight { get; }
    
    public float Height { get; }
    
    public  bool IsNeutered { get; }
    
    public bool IsVaccinated { get; }

    public static Result<HealthInformation> Create(float weight, float height, bool isNeutered, bool isVaccinated)
    {
        if(weight is < 0 or > Constants.MaxMeasurementValue)
            return Result.Failure<HealthInformation>("Weight must not be negative or longer than 100 kg!");
        
        if(height is < 0 or > Constants.MaxMeasurementValue)
            return Result.Failure<HealthInformation>("Height must not be negative or longer than 100 cm!");
        
        var healthInformation = new HealthInformation( weight, height, isNeutered, isVaccinated);
        
        return Result.Success(healthInformation);
    }
}