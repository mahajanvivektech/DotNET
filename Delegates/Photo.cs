namespace Delegates;

public record Photo
{
    public static Photo Load(string image) => new();
    
    public void Save() {}
}
