using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcMusicStore.AcceptanceTests;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MvcMusicStore.SpecFlowTests.StepDefinations
{
    [Binding]
    public class ShoppingCartDefinations
    {
        [Given("I have browsed the site")]
        public void GivenIHaveBrowsedTheSite()
        {
            WebBrowser.Current.GoTo("http://localhost:1200");
        }

        [When("I press Cart button")]
        public void WhenIPressCart()
        {
            WebBrowser.Current.Link(Find.ById("cart-status")).Click();
        }

        [When("Im logged in as testuser")]
        public void WhenILoggedInAsTestUser()
        {
            WebBrowser.Current.TextField(Find.ById("UserName")).TypeText("testuser");
            WebBrowser.Current.TextField(Find.ById("Password")).TypeText("password123!");
            WebBrowser.Current.Element(Find.ByValue("Log On")).Click();
        }

        [Then("I should be redirected to the login when i click on checkout")]
        public void RedirectToLogin()
        {
            WebBrowser.Current.Element(Find.ByText("Checkout >>")).Click();
            Assert.That(WebBrowser.Current.ContainsText("Please enter your username and password"));
        }

        [Then("I should be taken to the shipping page when i click logout")]
        public void RedirectToShippingPage()
        {
            WebBrowser.Current.Element(Find.ByValue("Checkout >>")).Click();
           Assert.That(WebBrowser.Current.ContainsText("Address And Payment"));
        }
    }
}
