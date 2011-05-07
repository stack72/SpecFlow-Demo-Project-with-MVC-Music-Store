using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using WatiN.Core;

namespace MvcMusicStore.WatiNTests
{
    [TestFixture]
    public class AdminTests
    {
        [Test]
        public void Check_For_Admin_Link_Present_When_Logged_In()
        {
            var result = false;
            var url = string.Empty;
            //Act
            using (IE netWindow = new IE("http://localhost:49573/default.aspx"))
            {

                LoginAsAdmin(netWindow);

                url = netWindow.Url;

                var adminLinkExists = netWindow.Link(Find.ById("ctl00_ucHeader_lnkAdminPage")).Exists;
                if (adminLinkExists)
                {
                    result = true;
                }
            }

            Assert.AreEqual("http://localhost:49573/default.aspx", url);
            Assert.IsTrue(result);
        }

        [Test]
        public void Check_That_When_Logged_In_As_Admin_Then_Admin_Link_Goes_To_Admin_HomePage()
        {
            var url = string.Empty;
            //Act
            using (IE netWindow = new IE("http://localhost:49573/default.aspx"))
            {
                LoginAsAdmin(netWindow);

                netWindow.Link(Find.ById("ctl00_ucHeader_lnkAdminPage")).Click();
                netWindow.WaitForComplete();

                url = netWindow.Url;
            }
            Assert.AreEqual("http://localhost:49573//administration/default.aspx", url);
        }

        [Test]
        public void Check_That_When_Not_Logged_In_As_Admin_Then_Trying_Admin_Link_Goes_To_Site_Home_Page()
        {
            var url = string.Empty;
            //Act
            using (IE netWindow = new IE("http://localhost:49573/default.aspx"))
            {
                netWindow.GoTo("http://localhost:49573//administration/default.aspx");
                url = netWindow.Url;
            }
            Assert.AreEqual("http://localhost:49573/default.aspx", url);
        }

        [Test]
        public void Check_That_When_Logged_In_As_Admin_Then_Add_Product_Works()
        {
            var result = false;
            using (IE netWindow = new IE("http://localhost:49573/default.aspx"))
            {
                LoginAsAdmin(netWindow);

                netWindow.Link(Find.ById("ctl00_ucHeader_lnkAdminPage")).Click();
                #region hidden new way
                netWindow.Link(Find.ById(new Regex("AdminPage$")));
                #endregion
                
                netWindow.WaitForComplete();

                netWindow.Button(Find.ById("ctl00_ucHeader_lnkProductAdmin")).Click();
                netWindow.WaitForComplete();

                netWindow.Button(Find.ById("ctl00_ContentPlaceHolder1_RadDock1_C_btnAddProduct")).Click();
                netWindow.WaitForComplete();

                netWindow.TextField(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_txtProductName")).TypeText(String.Format("Paul Test Product {0}", DateTime.Now.Ticks.ToString()));
                netWindow.SelectList(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_ddlProductManufacturer")).SelectByValue("3");
                netWindow.SelectList(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_ddlCategoryList")).SelectByValue("2");
                netWindow.WaitForComplete(100);
                netWindow.SelectList(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_ddlSubCategoryList")).SelectByValue("2");
                netWindow.WaitForComplete();
                netWindow.Link(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_btnAddCombo")).Click();
                netWindow.WaitForComplete();
                netWindow.TextField(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_txtProductPrice")).TypeText("19.99");
                netWindow.TextField(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_txtProductModel")).TypeText("Paul Test Model 1");
                netWindow.Link(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_btnSave")).Click();

                netWindow.WaitForComplete();

                Span resultMessage = netWindow.Span(Find.ById("ctl00_ContentPlaceHolder1_ucProduct_ucMessage_lblMessage"));
                if (resultMessage.Text == "New Product created successfuly")
                {
                    result = true;
                }
            }
            Assert.IsTrue(result);
        }

        private static void LoginAsAdmin(IE netWindow)
        {
            //go to login page
            netWindow.GoTo("http://localhost:49573/login.aspx");

            netWindow.TextField(Find.ById(new Regex("txtUserNameEntry$")).TypeText("paulstack@hotmail.com");
            netWindow.TextField(Find.ById("ctl00_ContentPlaceHolder1_ucLogin_txtPassword")).TypeText("");
            netWindow.Button(Find.ById("ctl00_ContentPlaceHolder1_ucLogin_btnLogin")).Click();
            netWindow.WaitForComplete(100);
        }
    }
}
