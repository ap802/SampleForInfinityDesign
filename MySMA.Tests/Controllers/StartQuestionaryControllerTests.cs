using System.Web.Mvc;
using MySMA.Controllers;
using NUnit.Framework;
using MySMA.Repositories;
using NSubstitute;
using MySMA.Models;
using System.Collections.Generic;
using System.Linq;

namespace MySMA.Tests.Controllers
{
    [TestFixture]
    public class StartQuestionaryControllerTests
    {
        private IRepository<Borrower> _borrowerRepo;
        private StartQuestionnaireController _controller;

        [SetUp]
        public void SetUp()
        {
            _borrowerRepo = Substitute.For<IRepository<Borrower>>();
            _controller = new StartQuestionnaireController(_borrowerRepo);
        }

        [Test]
        public void Index_ShowPage_GetDataFromRepository()
        {
            //Arrange
            _borrowerRepo.All.Returns(new List<Borrower>().AsQueryable());

            // Act
            _controller.Index();

            // Assert
            var data = _borrowerRepo.Received(1).All;
        }

        [Test]
        public void EnterBorrowersNameTest()
        {
            // Act
            var res = _controller.EnterBorrowersName() as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(res.RouteValues["action"], "Index");
            Assert.AreEqual(res.RouteValues["controller"], "BorrowerName");
        }
    }
}