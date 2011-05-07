using System.Linq;
using MvcMusicStore.AcceptanceTests;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;
using Table = TechTalk.SpecFlow.Table;

namespace MvcMusicStore.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class StoreBrowsingDefinitions
    {
        [Given(@"I Go To the home page")]
        public void GivenIGoToTheHomePage()
        {
            WebBrowser.Current.GoTo("http://localhost:1200/");

            WebBrowser.Current.BringToFront();
        }

        [When(@"I click the following link")]
        public void WhenIClickTheFollowingLink(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                WebBrowser.Current.Link(Find.ByText(tableRow["Value"])).Click();
                //we can run the test here if we want
            }
        }

        [Then(@"the album results should be displayed on the screen")]
        public void ThenTheAlbumResultsShouldBeDisplayedOnTheScreen()
        {
            Assert.IsTrue(WebBrowser.Current.List(Find.ById("album-list")).Children().Any());

            WebBrowser.Current.Close();
        }

    }
}
