using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence;

namespace TablePerComponent.App.RouteHandlers;

public static class CatRouteHandlers
{
    public static async Task<IResult> HandleAddPet(PetDbContext dbContext, Cat pet)
    {
        await dbContext.Cats.AddAsync(pet);
        await dbContext.SaveChangesAsync();
        return Results.Created("pet/{id}/cat", new { id = pet.Id });
    }
    
    public static async Task<IResult> HandleViewPet(PetDbContext dbContext, int id)
    {
        Cat? cat = await dbContext.Cats.FindAsync(id);

        return cat is null
            ? Results.NotFound()
            : Results.Ok(cat);
    }
}