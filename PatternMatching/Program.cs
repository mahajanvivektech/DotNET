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
        Console.WriteLine($"o is a Hero and is called {h.HeroName}");
    }

    if (o is not Hero) Console.WriteLine("No hero");
}

NewTypePattern();

void TypePatternAndCollections()
{
    IEnumerable<Person> persons = new[]
    {
        new Person("John", "Doe"),
        new Hero("Wade", "Wilson", "Deadpool", HeroType.FailedExperiment, false)
    };

    if (persons is IReadOnlyList<Person> pList && pList[1] is Hero h)
    {
        Console.WriteLine($"h is a Hero and is called {h.HeroName}");
    }
}

TypePatternAndCollections();

void NullCheckWithTypePattern()
{
    Hero? someone = null;
    Console.WriteLine(someone is Hero { Type: HeroType.FailedExperiment }
        ? $"someone is {someone.HeroName} and is not null"
        : "someone is null");
}

NullCheckWithTypePattern();

#endregion

#region Type pattern in Switch

WriteHeaderLine("Type Patterns in Switch statement");

void TypePatternInSwitch()
{
    object o = new Hero("Wade", "Wilson", "Deadpool", HeroType.FailedExperiment, false);
    switch (o)
    {
        case "Foo":
            Console.WriteLine("is a string Foo");
            break;
        case string s:
            Console.WriteLine($"o is a string {s}");
            break;
        case Hero h:
            break;
        case Person p:
            Console.WriteLine($"o is a person and has {p.FirstName}");
            break;
        case var obj: // var pattern
            Console.WriteLine($"o is just an object of type {o.GetType().Name}");
            break;
        default:
            throw new InvalidOperationException("Hmm, this should never happen...");
    }
}

TypePatternInSwitch();

void SwitchWithWhen()
{
    object o = new Hero("Wade", "Wilson", "Deadpool", HeroType.FailedExperiment, false);
    switch (o)
    {
        case Hero h when h.Type == HeroType.FailedExperiment:
            Console.WriteLine($"o Hero {h.HeroName} and became it because of an failed experiment");
            break;
        case Hero h:
            Console.WriteLine($"o is Hero {h.HeroName}, NOT because of a failed experiment");
            break;
        default:
            throw new InvalidOperationException("Hmm, this should never happen...");
    }

    var type = "fish";
    switch (type)
    {
        case "Person":
            Console.WriteLine("We have a Person");
            break;
        case "Hero":
            Console.WriteLine("We have a Hero");
            break;
        case var t when t.Trim().Length > 0:
            Console.WriteLine($"We have the special type {t}");
            break;
        default:
            throw new InvalidOperationException("type must not be empty");
    }
}

SwitchWithWhen();

void SwitchExpression()
{
    object o = new Hero("Wade", "Wilson", "Deadpool", HeroType.FailedExperiment, false);
    var result = o switch
    {
        // type pattern, var pattern, property pattern
        Hero { HeroName: var n, CanFly: true } => $"Hero {n} that can fly",
        Hero h => $"Hero {h.HeroName} {h.CanFly}",
        Person p => $"Person {p.LastName}",
        // discard pattern
        _ => throw new InvalidOperationException("What is that!!!")
    };
    Console.WriteLine(result);

    // switch with when
    var output = o switch
    {
        Hero h when h.CanFly => 2,
        Hero => 1,
        Person => 0,
        _ => throw new InvalidOperationException()
    };
    Console.WriteLine(output);
}

SwitchExpression();

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

internal record Person(string FirstName, string LastName, int? Age = null, Person? Assistant = null);

internal record Hero(string FirstName, string LastName, string HeroName, HeroType Type, bool CanFly) : Person(FirstName,
    LastName);
