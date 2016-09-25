using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using IspitiNRAKO;
using IspitiNRAKO.Controllers;
using IspitiNRAKO.Repozitorij;
using Moq;
using System.Data.Entity;
using System.Web;

namespace IspitiNRAKOTest
{
    [TestClass]
    public class LoginControllerTest
    {

        

        [TestMethod]
        public void LoginRedirectTest()
        {
            LoginController controller = new LoginController();

            ViewResult result = controller.Login("1", "1") as ViewResult;

            Assert.AreEqual("Login", result.ViewName);

        }


        

    }
}
