#region Constant Pattern

WriteHeaderLine("Constant Pattern");

void ConstantPattern()
{
    object something = 42;
    if (something is 42) Console.WriteLine("Something is 42");
}

ConstantPattern();

#endregion

#region Type Pattern

WriteHeaderLine("Type Pattern");

void GoodOldTypeCheck()
{
    object o = new Hero("Wade", "Wilson", "Deadpool", HeroType.FailedExperiment, false);
    var h = o as Hero;
    if (h is not null) Console.WriteLine($"o is a Hero and is called {h.HeroName}");
}

GoodOldTypeCheck();

void NewTypePattern()
{
    object o = new Hero("Wade", "Wilson", "Deadpool", HeroType.FailedExperiment, false);
    if (o is Hero h)
    {
        Console.WriteLine($"h is of type {h.GetType().Name}");
        Console.WriteLine($"h is a Hero and is called {h.HeroName}");
    }

    if (o is not Hero) Console.WriteLine("No hero");
}

NewTypePattern();

#endregion

void WriteHeaderLine(string pattern) => Console.WriteLine(pattern);

internal enum HeroType
{
    NuclearAccident,
    FailedExperiment,
    Alien,
    Mutant,
    Technology,
    Other
};

internal record Hero(string FirstName, string LastName, string HeroName, HeroType Type, bool CanFly);
