namespace TablePerComponent.App.Models;

public abstract class Pet
{
    public int Id { get; init; }
    public required NonEmptyString Name { get; init; }

    public abstract void Speak();
}

public class Dog : Pet
{
    public required NonEmptyString Breed { get; init; }
    public NonEmptyString? Color { get; init; }
    public required Owner Owner { get; init; }

    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Pet
{
    public required NonEmptyString Breed { get; init; }
    public NonEmptyString? Color { get; init; }

    public override void Speak()
    {
        Console.WriteLine("Miaw!");
    }
}

public class Bird : Pet
{
    public required NonEmptyString Species { get; init; }
    public override void Speak()
    {
        Console.WriteLine("Chirp!");
    }
}