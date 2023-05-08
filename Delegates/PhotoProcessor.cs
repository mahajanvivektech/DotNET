namespace Delegates;

public record PhotoProcessor
{
    public delegate void PhotoFilterHandler(Photo photo);

    public void Process(string image, PhotoFilterHandler filter)
    {
        var photo = Photo.Load(image);
        filter(photo);
        photo.Save();
    }

    public void Process(string image, Action<Photo> filter)
    {
        var photo = Photo.Load(image);
        filter(photo);
        photo.Save();
    }
}
