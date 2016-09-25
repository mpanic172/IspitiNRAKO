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

namespace IspitiNRAKOTest
{
    [TestClass]
    public class KompanijaControllerTest
    {
        [TestMethod]
        public void KompanijaIndex()
        {
            KompanijaController controller = new KompanijaController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void KompanijaDetails()
        {
            KompanijaController controller = new KompanijaController();

            ViewResult result = controller.Details(4) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void KompanijaCreate()
        {
            KompanijaController controller = new KompanijaController();

            ViewResult result = controller.Create() as ViewResult;
            var kompanija = (Kompanija)result.ViewData.Model;

            Assert.AreEqual(0, kompanija.IdKompanija);
        }

        [TestMethod]
        public void KompanijaDelete()
        {
            KompanijaController controller = new KompanijaController();

            var result = controller.Delete(-1) as HttpNotFoundResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void KompanijaEdit()
        {
            KompanijaController controller = new KompanijaController();

            ViewResult result = controller.Edit(4) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void KompanijaMockCreate()
        {

            Kompanija kompMock = new Kompanija();
            kompMock.Naziv = "Mock kompanija";

            var mockSet = new Mock<DbSet<Kompanija>>();
            var mockContext = new Mock<IspitiEntities>();
            mockContext.Setup(k => k.Kompanijas).Returns(mockSet.Object);

            var service = new KompanijaRepozitorij(mockContext.Object);
            service.Add(kompMock);
            service.Save();

            mockSet.Verify(m => m.Add(It.IsAny<Kompanija>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [TestMethod]
        public void KompanijaMockDelete()
        {

            Kompanija kompMock = new Kompanija();
            kompMock.Naziv = "Mock kompanija 1";
            
            var mockSet = new Mock<DbSet<Kompanija>>();
            var mockContext = new Mock<IspitiEntities>();
            mockContext.Setup(k => k.Kompanijas).Returns(mockSet.Object);

            var service = new KompanijaRepozitorij(mockContext.Object);
            service.Delete(kompMock);
            service.Save();

            mockSet.Verify(m => m.Remove(It.IsAny<Kompanija>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [TestMethod]
        public void KompanijaMockDeleteFromList()
        {

            Kompanija kompMock = new Kompanija();
            kompMock.Naziv = "Mock kompanija 1";
            Kompanija kompMock2 = new Kompanija();
            kompMock.Naziv = "Mock kompanija 1";
            Kompanija kompMock3 = new Kompanija();
            kompMock.Naziv = "Mock kompanija 3";
            Kompanija kompMock4 = new Kompanija();
            kompMock.Naziv = "Mock kompanija 2";
            Kompanija kompMock5 = new Kompanija();
            kompMock.Naziv = "Mock kompanija 2";

            var komps = new List<Kompanija>() { kompMock, kompMock2, kompMock3, kompMock4, kompMock5 };

            var mockRepository = new Mock<KompanijaRepozitorij>();
            mockRepository.Setup(kp => kp.GetKomps()).Returns(komps);

            mockRepository.Setup(ev => ev.Del(It.IsAny<Kompanija>()))
            .Callback((Kompanija unit) =>
            {
                komps.RemoveAll(e => e.IdKompanija == unit.IdKompanija);
            });

            mockRepository.Setup(ev => ev.Count()).Returns(() => { return komps.Count; });

            KompanijaRepozitorij KompanijaMockDatabase = mockRepository.Object;

            var kompanijaObjects = new List<Kompanija>();
            var duplicateKompanijaObjects = new List<Kompanija>();
            

            foreach (Kompanija item in KompanijaMockDatabase.GetAll)
            {
                var ko = kompanijaObjects.Where(
                    e => e.Naziv.Equals(item.Naziv)
                ).ToList();
                if (ko.Count == 0)
                {
                    kompanijaObjects.Add(item);
                }
                else
                {
                    duplicateKompanijaObjects.Add(item);
                }


            }

            Assert.AreEqual(0, duplicateKompanijaObjects.Count);

            foreach (Kompanija k in duplicateKompanijaObjects)
            {
                
                KompanijaMockDatabase.Del(k);
                
            }

            
            int count = komps.Count;

            Assert.AreEqual(5, count);

        }

        [TestMethod]
        public void KompanijaQuerySelect()
        {
            var data = new List<Kompanija>
            {
                new Kompanija { Naziv = "BBB" },
                new Kompanija { Naziv = "ZZZ" },
                new Kompanija { Naziv = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Kompanija>>();
            mockSet.As<IQueryable<Kompanija>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Kompanija>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Kompanija>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Kompanija>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IspitiEntities>();
            mockContext.Setup(c => c.Kompanijas).Returns(mockSet.Object);

            var service = new KompanijaRepozitorij(mockContext.Object);
            var komps = service.GetAll.ToList();

            Assert.AreEqual(3, komps.Count);

        }


    }
}
