using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace PlaywrightTest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class EMR登入測試 : PageTest
    {
        [Test]
        public async Task 登入Test()
        {
            await Page.GotoAsync("http://10.10.10.160:8035/");

            await Page.GetByPlaceholder("Name").ClickAsync();

            await Page.GetByPlaceholder("Name").FillAsync("admin");

            await Page.GetByPlaceholder("Name").PressAsync("Tab");

            await Page.GetByPlaceholder("Password").FillAsync("tech8494");

            //// 等待登入Api回應(登入 Api Url)
            //var waitForResponseTask = Page.WaitForResponseAsync("http://10.10.10.160:8097/TgEmrApi/Login");

            await Page.GetByPlaceholder("Password").PressAsync("Enter");

            //var Response = await waitForResponseTask;

            //// Response Http Status Code
            //var Status = Response.Status;

            //// Response Content
            //var data = await Response.JsonAsync();

            //Assert.That(Status, Is.EqualTo(200));
            await Page.GetByRole(AriaRole.Link, new() { NameString = "查閱" }).ClickAsync();


            Assert.That(HttpUtility.UrlDecode(Page.Url), Is.EqualTo("http://10.10.10.160:8035/查閱"));

            //await Expect(Page).ToHaveURLAsync(new Regex(@"%e6%9f%a5%e9%96%b1"));
        }
    }
}
