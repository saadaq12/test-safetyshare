using Microsoft.Playwright.NUnit;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace Hello.Tests;

public class LocalizationTests : PageTest 
{
    [Test]
    public async Task VerifyLanguageSwitch() 
    {
        string jsonString = await File.ReadAllTextAsync("TestData.json");
        var testData = JsonSerializer.Deserialize<JsonElement>(jsonString);
        
        await Page.GotoAsync("https://safelyshare.se/");
        
        // Verifierar HTML-taggen (ditt krav för torsdagen)
        var htmlTag = Page.Locator("html");
        await Expect(htmlTag).ToHaveAttributeAsync("lang", "en");
    }
}