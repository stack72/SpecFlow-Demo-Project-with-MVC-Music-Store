using MvcMusicStore.AcceptanceTests;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MvcMusicStore.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class ProductDefinitions
    {

        [Given("I have hit the site")]
        public void GivenIHaveHitTheSite()
        {
            WebBrowser.Current.GoTo("http://localhost:1200/");

            WebBrowser.Current.BringToFront();

        }

        [When("I have gone to the rock genre page")]
        public void WhenIHaveGoneToTheRockGenrePage()
        {
            WebBrowser.Current.Link(Find.ByText("Rock")).Click();
        }

        [When("I select 'facelift'")]
        public void WhenISelectFacelift()
        {
            WebBrowser.Current.Link(Find.ByText("Facelift")).Click();
        }

        [Then("I should be shown the artist and the price")]
        public void IWillBeShownTheArtistAndThePrice()
        {
            Assert.That(WebBrowser.Current.ContainsText("Price"));
            Assert.That(WebBrowser.Current.ContainsText("Artist"));
        }

        [Then("I should be offered a chance to add the purchase to the cart")]
        public void IWillBeOfferedTheChanceToPurchaseTheAlbum()
        {
            Assert.That(WebBrowser.Current.Link(Find.ByText("Add to cart")).Exists);
            WebBrowser.Current.Close();
        }

        [Then("I should be shown the item in the cart when I click add to cart")]
        public void IAmShownTheItemInTheCartWhenIAddIt()
        {
            WebBrowser.Current.Link(Find.ByText("Add to cart")).Click();
            Assert.That(WebBrowser.Current.Link(Find.ByText("Checkout >>")).Exists);
            Assert.That(WebBrowser.Current.ContainsText("Facelift"));
            WebBrowser.Current.Close();
        }
    }
}
