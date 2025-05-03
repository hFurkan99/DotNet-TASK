// with an arrow delegate
var task = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith((data) =>
{
    Console.WriteLine("Data Length: " + data.Result.Length);
});

Console.WriteLine("Other Works");
await task;

// with a separate function
var task2 = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(run);

static void run(Task<string> data)
{
    Console.WriteLine("Data Length: " + data.Result.Length);
    //100 lines of code
}

Console.WriteLine("Other Works");
await task2;

// best practice
var task3 = new HttpClient().GetStringAsync("https://www.google.com");
Console.WriteLine("Other Works");
var data = await task3;
Console.WriteLine("Data Length: " + data.Length);