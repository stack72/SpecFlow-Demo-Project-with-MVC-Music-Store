using MvcMusicStore.AcceptanceTests;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MvcMusicStore.SpecFlowTests.StepDefinitions
{
    [Binding]
    public class HomePageDefinitions
    {
        [Given(@"I go directly to the home page")]
        public void GivenIGoToTheHomePage()
        {
            WebBrowser.Current.GoTo("http://localhost:1200/");

            WebBrowser.Current.BringToFront();
        }

        [Then(@"I should see the fresh off the grill results")]
        public void ThenIshouldSeeFreshOfftheGrillResults()
        {
            Assert.IsTrue(WebBrowser.Current.List(Find.ById("album-list")).Children().Count > 0);
            WebBrowser.Current.Close();
        }

        [Then(@"I should see the promotion panel")]
        public void ThenIShouldSeeThePromotionPanel()
        {
            Assert.IsTrue(WebBrowser.Current.Div(Find.ById("promotion")).Exists);
            WebBrowser.Current.Close();
        }
    }
}
