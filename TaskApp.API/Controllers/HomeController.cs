using Microsoft.AspNetCore.Mvc;

namespace TaskApp.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("get-google")]
    public async Task<IActionResult> GetContentAsync()
    {
        var task = new HttpClient().GetStringAsync("https://www.google.com");
        var data = await task; 
        return Ok(data);
    }

    [HttpGet("read-file")]
    public async Task<IActionResult> GetContent()
    {
        string data;
        string data2;
        
        Task<string> fileContent = ReadFileAsync();

        data = await new HttpClient().GetStringAsync("https://www.google.com");
        data2 = await fileContent;

        return Ok(string.Concat(data, data2));
    }

    private static Task<string> ReadFileAsync()
    {
        using StreamReader s = new("dosya.txt");
        return s.ReadToEndAsync();
    }
}
