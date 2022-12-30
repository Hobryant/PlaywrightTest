using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlaywrightTest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class EMR查閱測試 : PageTest
    {
        [Test]
        public async Task MyTest()
        {
            await Page.GotoAsync("http://10.10.10.160:8035/");

            await Page.GetByPlaceholder("Name").ClickAsync();

            await Page.GetByPlaceholder("Name").FillAsync("admin");

            await Page.GetByPlaceholder("Name").PressAsync("Tab");

            await Page.GetByPlaceholder("Password").FillAsync("tech8494");



            await Page.GetByPlaceholder("Password").PressAsync("Enter");

            // 等待登入Api回應(登入 Api Url)
            var waitForResponseTask = Page.WaitForResponseAsync("http://10.10.10.160:8097/TgEmrApi/LookUp");

            await Page.GetByRole(AriaRole.Link, new() { NameString = "查閱" }).ClickAsync();

            var Response = await waitForResponseTask;

            // Response Http Status Code
            var Status = Response.Status;

            // Response Content
            var data = await Response.JsonAsync();

            var 簽章人員 = await Page.Locator("select").First.InnerHTMLAsync();

            var 搜尋類型 = await Page.Locator("select").Nth(1).InnerHTMLAsync();

            var 查閱清單 = await Page.Locator("table").First.InnerHTMLAsync();

            Assert.AreEqual(200, Status);
        }
    }
}
