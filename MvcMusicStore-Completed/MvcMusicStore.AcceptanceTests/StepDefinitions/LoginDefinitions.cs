using MvcMusicStore.AcceptanceTests;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MvcMusicStore.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class LoginDefinitions
    {
        [Given(@"I have filled out all required information")]
        public void GivenIHaveFilledOutAllRequiredInformation()
        {
            WebBrowser.Current.GoTo("http://localhost:1200/");

            WebBrowser.Current.BringToFront();

            WebBrowser.Current.Link(Find.ByText("Admin")).Click();

            WebBrowser.Current.TextField(Find.ById("UserName")).TypeText("administrator");

            WebBrowser.Current.TextField(Find.ById("Password")).TypeText("password123!");
        }

        [Given(@"I have filled out all required information incorrectly")]
        public void GivenIHaveFilledOutAllRequiredInformationInforrectly()
        {
            WebBrowser.Current.GoTo("http://localhost:1200/");

            WebBrowser.Current.BringToFront();

            WebBrowser.Current.Link(Find.ByText("Admin")).Click();

            WebBrowser.Current.TextField(Find.ById("UserName")).TypeText("admin");

            WebBrowser.Current.TextField(Find.ById("Password")).TypeText("admin");
        }

        [When(@"I press Log In")]
        public void WhenIPressLogIn()
        {
            WebBrowser.Current.Button(Find.ByValue("Log On")).Click();
        }

        [Then(@"I should be redirected to the full list of record entries")]
        public void ThenIShouldBeRedirectedToTheFullListOfRecordEntriesAndSeeACreateNewMessage()
        {
            Assert.IsTrue(WebBrowser.Current.Link(Find.ByText("Create New")).Exists);
            WebBrowser.Current.Close();
        }

        [Then(@"I should be shown a message to show login was unsuccessful")]
        public void ThenIShouldBeShownMessageToSayLoginUnsuccessful()
        {
            Assert.IsTrue(WebBrowser.Current.ContainsText("Login was unsuccessful."));
            WebBrowser.Current.Close();
        }
    }
}
