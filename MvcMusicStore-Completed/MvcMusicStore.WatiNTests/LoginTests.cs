using NUnit.Framework;
using WatiN.Core;

namespace MvcMusicStore.WatiNTests
{
    [TestFixture]
    [RequiresSTA]
    public class LoginTests
    {
        [Test]
        public void SuccessfulAdministrationLogin()
        {
            var browserUrl = string.Empty;
            using (var browser = new IE("http://localhost:1200/"))
            {
                browser.Link(Find.ByText("Admin")).Click();
                browser.TextField(Find.ById("UserName")).TypeText("administrator");
                browser.TextField(Find.ById("Password")).TypeText("password123!");

                browser.Element(Find.ByValue("Log On")).Click();
                browser.WaitForComplete(2);

                browserUrl = browser.Url;
            }

            Assert.That(browserUrl.Contains("/StoreManager"), string.Format("Browser Url is incorrect - it is actually {0}", browserUrl));
        }

        [Test]
        public void UnsuccessfulAdministrationLogin()
        {
            bool result;
            using (var browser = new IE("http://localhost:1200/"))
            {
                browser.Link(Find.ByText("Admin")).Click();
                browser.TextField(Find.ById("UserName")).TypeText("admin");
                browser.TextField(Find.ById("Password")).TypeText("admin");

                browser.Element(Find.ByValue("Log On")).Click();

                result = browser.ContainsText("Login was unsuccessful.");
            }

            Assert.That(result, "Browser Url is incorrect");
        }
    }
}
