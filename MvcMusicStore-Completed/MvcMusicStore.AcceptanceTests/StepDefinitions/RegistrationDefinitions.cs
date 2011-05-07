using System;
using System.Text;
using MvcMusicStore.AcceptanceTests;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MvcMusicStore.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class RegistrationDefinitions
    {
        [Given(@"I have gone to the login page")]
        public void GivenIGoToTheLoginPage()
        {
            WebBrowser.Current.GoTo("http://localhost:1200/Account/Logon");

            WebBrowser.Current.BringToFront();
        }

        [When(@"I click on the Register link")]
        public void WhenIClickTheRegisterLink()
        {
            WebBrowser.Current.Link(Find.ByText("Register")).Click();
        }

        [When(@"I enter some correct user details")]
        public void WhenIEnterCorrectUserDetails()
        {
            WebBrowser.Current.TextField(Find.ById("UserName")).TypeText(GetRandomString());
            WebBrowser.Current.TextField(Find.ById("Email")).TypeText(string.Format("{0}@winrooms.co.uk", GetRandomString()));
            WebBrowser.Current.TextField(Find.ById("Password")).TypeText("password123!");
            WebBrowser.Current.TextField(Find.ById("ConfirmPassword")).TypeText("password123!");
            WebBrowser.Current.Button(Find.ByValue("Register")).Click();
        }

        [When(@"I enter user details with a password thats too short")]
        public void EnterAUserPasswordThatsTooShort()
        {
            WebBrowser.Current.TextField(Find.ById("UserName")).TypeText(GetRandomString());
            WebBrowser.Current.TextField(Find.ById("Email")).TypeText(string.Format("{0}@winrooms.co.uk", GetRandomString()));
            WebBrowser.Current.TextField(Find.ById("Password")).TypeText("test");
            WebBrowser.Current.TextField(Find.ById("ConfirmPassword")).TypeText("test");
            WebBrowser.Current.Button(Find.ByValue("Register")).Click();
        }

        [When(@"I enter user details with a password thats not complex enough")]
        public void EnterAUserPasswordThatIsNotComplexEnough()
        {
            WebBrowser.Current.TextField(Find.ById("UserName")).TypeText(GetRandomString());
            WebBrowser.Current.TextField(Find.ById("Email")).TypeText(string.Format("{0}@winrooms.co.uk", GetRandomString()));
            WebBrowser.Current.TextField(Find.ById("Password")).TypeText("testing");
            WebBrowser.Current.TextField(Find.ById("ConfirmPassword")).TypeText("testing");
            WebBrowser.Current.Button(Find.ByValue("Register")).Click();
        }

        [Then(@"I will be successfully registered")]
        public void ThenIwillBeSuccessfullyRegistered()
        {
            Assert.IsTrue(WebBrowser.Current.Url == "http://localhost:1200/", string.Format("Url was incorrect - currently {0}", WebBrowser.Current.Url));
            WebBrowser.Current.Close();
        }

        [Then(@"I will not have been able to register due to password being too short")]
        public void ThenIWillNotBeRegisteredAndShownAPasswordTooShortMessage()
        {
            Assert.That(WebBrowser.Current.ContainsText("Account creation was unsuccessful"));
            Assert.That(WebBrowser.Current.ContainsText("The Password must be at least 6 characters long."));
            WebBrowser.Current.Close();
        }

        [Then(@"I will not have been able to register due to wrong password value")]
        public void ThenIWillNotBeRegisteredAndShownAPasswordNotCorrectMessage()
        {
            Assert.That(WebBrowser.Current.ContainsText("Account creation was unsuccessful"));
            Assert.That(WebBrowser.Current.ContainsText("The password provided is invalid. Please enter a valid password value"));
            WebBrowser.Current.Close();
        }

        private string GetRandomString()
        {
            var builder = new StringBuilder();
            var random = new Random();
            char ch;
            for (int i = 0; i < 20; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString().ToLower();
        }
    }
}
