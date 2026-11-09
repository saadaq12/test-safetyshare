using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Hello.Tests;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public async Task GotoAsync()
    {
        await _page.GotoAsync("https://safelyshare.se/");
    }

    public ILocator MainHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Something new is coming" });
}