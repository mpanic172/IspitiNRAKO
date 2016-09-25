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
using System.Web.Routing;

namespace IspitiNRAKOTest
{
    [TestClass]
    public class SecurityTest
    {
        protected Mock<HttpContextBase> HttpContextBaseMock;
        protected Mock<HttpRequestBase> HttpRequestMock;
        protected Mock<HttpResponseBase> HttpResponseMock;

        [TestInitialize]
        public void TestInitialize()
        {
            HttpContextBaseMock = new Mock<HttpContextBase>();
            HttpRequestMock = new Mock<HttpRequestBase>();
            HttpResponseMock = new Mock<HttpResponseBase>();
            HttpContextBaseMock.SetupGet(x => x.Request).Returns(HttpRequestMock.Object);
            HttpContextBaseMock.SetupGet(x => x.Response).Returns(HttpResponseMock.Object);
        }

        protected KompanijaController SetupController()
        {
            var routes = new RouteCollection();
            var controller = new KompanijaController();
            controller.ControllerContext = new ControllerContext(HttpContextBaseMock.Object, new RouteData(), controller);
            controller.Url = new UrlHelper(new RequestContext(HttpContextBaseMock.Object, new RouteData()), routes);
            return controller;
        }

        [TestMethod]
        public void IndexTest()
        {
            
        }
    }
}
