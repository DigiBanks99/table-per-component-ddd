using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence;

namespace TablePerComponent.App.RouteHandlers;

public static class DogRouteHandlers
{
    public static async Task<IResult> HandleAddPet(PetDbContext dbContext, Dog pet)
    {
        await dbContext.Dogs.AddAsync(pet);
        await dbContext.SaveChangesAsync();
        return Results.Created("pet/{id}/dog", new { id = pet.Id });
    }

    public static async Task<IResult> HandleViewPet(PetDbContext dbContext, int id)
    {
        Dog? dog = await dbContext.Dogs.FindAsync(id);

        return dog is null
            ? Results.NotFound()
            : Results.Ok(dog);;
    }
}