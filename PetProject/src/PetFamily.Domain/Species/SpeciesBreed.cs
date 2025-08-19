using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public record SpeciesBreed
{
    private SpeciesBreed(Guid speciesId, Guid breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }
    
    public Guid SpeciesId { get; }
    
    public Guid BreedId { get; }

    public static Result<SpeciesBreed> Create(Guid speciesId, Guid breedId)
    {
        if (speciesId == Guid.Empty)
            Result.Failure<SpeciesBreed>("SpeciesId breed cannot be empty.");
        
        if(breedId == Guid.Empty)
            Result.Failure<SpeciesBreed>("BreedId cannot be empty.");

        var speciesBreed = new SpeciesBreed(speciesId, breedId);
        
        return Result.Success(speciesBreed);
    }
}