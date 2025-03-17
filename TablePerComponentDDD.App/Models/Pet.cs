namespace TablePerComponent.App.Models;

public abstract class Pet
{
    public int Id { get; init; }
    public required string Name { get; init; }

    public abstract void Speak();
}

public class Dog : Pet
{
    public required string Breed { get; init; }
    public string? Color { get; init; }
    public required Owner Owner { get; init; }

    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Pet
{
    public required string Breed { get; init; }
    public string? Color { get; init; }
    public override void Speak()
    {
        Console.WriteLine("Miaw!");
    }
}

public class Bird : Pet
{
    public required string Species { get; init; }
    public override void Speak()
    {
        Console.WriteLine("Chirp!");
    }
}