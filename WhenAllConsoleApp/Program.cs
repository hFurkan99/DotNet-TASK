namespace WhenAllConsoleApp;

public class Content
{
    public string Site { get; set; } = default!;
    public int Len { get; set; }
}

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main Thread: " + Environment.CurrentManagedThreadId);

        List<string> urlsList = new([
            "https://www.google.com",
            "https://www.microsoft.com",
            "https://www.amazon.com"]);

        List<Task<Content>> taskList = [];

        urlsList.ToList().ForEach(url =>
        {
            taskList.Add(GetContentAsync(url));
        });

        var contents = await Task.WhenAll(taskList);

        contents.ToList().ForEach(content =>
        {
            Console.WriteLine($"{content.Site} length:{content.Len}");
        });
    }


    public static async Task<Content> GetContentAsync(string url)
    {
        var data = await new HttpClient().GetStringAsync(url);

        Content content = new()
        {
            Site = url,
            Len = data.Length
        };

        Console.WriteLine("GetContentAsync Thread: " + Environment.CurrentManagedThreadId);
        return content;
    }
}

