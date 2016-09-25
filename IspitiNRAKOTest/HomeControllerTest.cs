using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using IspitiNRAKO;
using IspitiNRAKO.Controllers;

namespace IspitiNRAKOTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {

            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
