using System.Linq;
using NUnit.Framework;
using WatiN.Core;

namespace MvcMusicStore.WatiNTests
{
    [TestFixture]
    [RequiresSTA]
    public class HomePageTests
    {
        [Test]
        public void HomePageContainsFreshOffTheGrillAlbumList()
        {
            using (var browser = new IE("http://localhost:1200/"))
            {
                Assert.IsTrue(browser.List(Find.ById("album-list")).Children().Any());
            }
        }

        [Test]
        public void HomePageContainsPromotionPanel()
        {
            using (var browser = new IE("http://localhost:1200/"))
            {
                Assert.IsTrue(browser.Div(Find.ById("promotion")).Exists);
            }
        }
    }
}
