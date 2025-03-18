using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence;

namespace TablePerComponent.App.RouteHandlers;

public static class BirdRouteHandlers
{
    public static async Task<IResult> HandleAddPet(PetDbContext dbContext, Bird pet)
    {
        await dbContext.Birds.AddAsync(pet);
        await dbContext.SaveChangesAsync();
        return Results.Created("pet/{id}/bird", new { id = pet.Id });
    }
    
    public static async Task<IResult> HandleViewPet(PetDbContext dbContext, int id)
    {
        Bird? bird = await dbContext.Birds.FindAsync(id);

        return bird is null
            ? Results.NotFound()
            : Results.Ok(bird);
    }
}