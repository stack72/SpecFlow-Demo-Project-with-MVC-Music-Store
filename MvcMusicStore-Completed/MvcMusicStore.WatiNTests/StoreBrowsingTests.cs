using System.Linq;
using NUnit.Framework;
using WatiN.Core;

namespace MvcMusicStore.WatiNTests
{
    [TestFixture]
    [RequiresSTA]
    public class StoreBrowsingTests
    {
        [Test]
        public void BrowsingByGenreReturnsAlbumList()
        {
            using (var browser = new IE("http://localhost:1200/"))
            {
                browser.Link(Find.ByText("Rock")).Click();
                Assert.IsTrue(browser.List(Find.ById("album-list")).Children().Any());
            }
        }
    }
}
