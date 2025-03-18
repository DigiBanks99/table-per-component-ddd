using Microsoft.EntityFrameworkCore;

using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence;

namespace TablePerComponent.App.RouteHandlers;

public static class PetRouteHandlers
{
    public static async Task<IResult> HandleViewPets(PetDbContext dbContext)
    {
        List<Pet> pets = await dbContext.Pets.ToListAsync();

        return Results.Ok(pets);
    }
    
    public static async Task<IResult> HandleViewPet(PetDbContext dbContext, int id)
    {
        Pet? pet = await dbContext.Pets.FindAsync(id);
        return pet is null
            ? Results.NotFound()
            : Results.Ok(pet);
    }
}