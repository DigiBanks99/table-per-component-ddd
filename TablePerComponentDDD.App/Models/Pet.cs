namespace TablePerComponent.App.Models;

public abstract class Pet(int id, NonEmptyString name)
{
    public int Id { get; } = id;
    public NonEmptyString Name { get; } = name;

    public abstract void Speak();
}

public sealed class Dog : Pet
{
    [Obsolete("Only to be used for EF Core until https://github.com/dotnet/efcore/issues/12078 is fixed.")]
    private Dog(int id, NonEmptyString name, NonEmptyString breed, RichColor? color) : base(id, name)
    {
        Breed = breed;
        Color = color;
    }

    private Dog(NonEmptyString name, NonEmptyString breed, RichColor? color, Owner? owner) : base(0, name)
    {
        Breed = breed;
        Color = color;
        Owner = owner;
    }

    public static Dog Create(NonEmptyString name, NonEmptyString breed, RichColor? color, Owner? owner)
    {
        return new Dog(name, breed, color, owner);
    }

    public NonEmptyString Breed { get; private init; }
    public RichColor? Color { get; private init; }
    public Owner? Owner { get; private set; }

    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }

    public void UpdateOwner(Owner owner)
    {
        Owner = owner;
    }
}

public class Cat : Pet
{
    [Obsolete("Only to be used for EF Core until https://github.com/dotnet/efcore/issues/12078 is fixed.")]
    private Cat(int id, NonEmptyString name, NonEmptyString breed, RichColor? color) : base(id, name)
    {
        Breed = breed;
        Color = color;
    }

    private Cat(NonEmptyString name, NonEmptyString breed, RichColor? color) : base(0, name)
    {
        Breed = breed;
        Color = color;
    }

    public static Cat Create(NonEmptyString name, NonEmptyString breed, RichColor? color)
    {
        return new Cat(name, breed, color);
    }

    public NonEmptyString Breed { get; private init; }
    public RichColor? Color { get; private init; }

    public override void Speak()
    {
        Console.WriteLine("Miaw!");
    }
}

public class Bird : Pet
{
    [Obsolete("Only to be used for EF Core until https://github.com/dotnet/efcore/issues/12078 is fixed.")]
    private Bird(int id, NonEmptyString name, NonEmptyString species) : base(id, name)
    {
        Species = species;
    }

    private Bird(NonEmptyString name, NonEmptyString species) : base(0, name)
    {
        Species = species;
    }

    public static Bird Create(NonEmptyString name, NonEmptyString species)
    {
        return new Bird(name, species);
    }

    public NonEmptyString Species { get; private init; }

    public override void Speak()
    {
        Console.WriteLine("Chirp!");
    }
}