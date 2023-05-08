using Delegates;

var photoProcessor = new PhotoProcessor();
var filters = new PhotoFilters();

// Delegate
PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
filterHandler += filters.ApplyContrast;
filterHandler += RemoveRedEyeFilter;
photoProcessor.Process("photo.jpg", filterHandler);

// Built-in delegate
Action<Photo> photoFilterHandler = filters.ApplyBrightness;
photoFilterHandler += filters.ApplyContrast;
photoFilterHandler += RemoveRedEyeFilter;
photoProcessor.Process("photo.jpg", photoFilterHandler);

void RemoveRedEyeFilter(Photo photo) => Console.WriteLine("Remove red eye");
