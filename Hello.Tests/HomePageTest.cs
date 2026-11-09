using Microsoft.Playwright.NUnit;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Hello.Tests;

public class HomePageTests : PageTest 
{
    private HomePage _homePage;

    [SetUp]
    public async Task Setup()
    {
        _homePage = new HomePage(Page);
        await _homePage.GotoAsync();
    }

    [Test]
    public async Task VerifyTitleIsCorrect() 
    {
        await Expect(Page).ToHaveTitleAsync(new Regex("SafelyShare"));
    }

    [Test]
    public async Task VerifyMainHeadingIsCorrect() 
    {
        await Expect(_homePage.MainHeading).ToBeVisibleAsync();
    }
}