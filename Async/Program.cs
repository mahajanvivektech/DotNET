var getHtmlTask = GetHtmlAsync("https://www.google.com/");
Console.WriteLine("Waiting for the task to complete...");
var result = await getHtmlTask;
Console.WriteLine(result[..10]);

async Task<string> GetHtmlAsync(string url)
{
    var httpClient = new HttpClient();
    return await httpClient.GetStringAsync(url);
}
