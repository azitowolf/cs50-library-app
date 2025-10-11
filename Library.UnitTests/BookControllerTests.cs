using Library.DomainModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Library.Web.Controllers;
using Library.Services.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Library.Web.Models;
using System.Net.Http;

namespace Library.UnitTests
{

    [TestFixture]
    public class BookControllerTests
    {
        private Mock<IBookService> _fakeBookService { get; set; }
        private Mock<IAuthorService> _fakeAuthorService { get; set; }
        private Mock<ILogger<HomeController>> _fakeLogger { get; set; }

        [SetUp]
        public void Init()
        {
            //Arrange
            _fakeBookService = new Mock<IBookService>();
            _fakeAuthorService = new Mock<IAuthorService>();
            _fakeLogger = new Mock<ILogger<HomeController>>();
        }

        [TearDown]
        public void Dispose()
        {
            Console.WriteLine("tearing Down");
            // deleting the items from DB if any added
            // generally revert everything to state before tests ran
            // in controller code, 
        }
        [TestCase]
        public async Task Index_ReturnsAViewWithListOfBooks()
        {
            //Arrange
            var controller = new BooksController(_fakeLogger.Object, _fakeBookService.Object, _fakeAuthorService.Object, null);
            _fakeBookService.Setup(i => i.GetAll(null, null, null, null))
                .ReturnsAsync(new List<Book>() { new Book(), new Book()});

            //Act
            var result = await controller.Index(null, null, null, null);

            //Assert
            Assert.IsInstanceOf((new ViewResult().GetType()), result);
            var viewResult = result as ViewResult;
            Assert.IsAssignableFrom<BooksViewModel>(viewResult.ViewData.Model);
            var model = viewResult.ViewData.Model as BooksViewModel;
            Assert.AreEqual(2, model.Books.Count());
        }
        [TestCase]
        public async Task Detail_ReturnsAViewWithASingleBook()
        {
            //Arrange
            var controller = new BooksController(_fakeLogger.Object, _fakeBookService.Object, _fakeAuthorService.Object, null);
            _fakeBookService.Setup(i => i.GetOne(0))
                .ReturnsAsync(new Book());

            //Act
            var result = await controller.Detail(0);

            //Assert
            Assert.IsInstanceOf((new ViewResult().GetType()), result);
            var viewResult = result as ViewResult;

            Assert.IsAssignableFrom<Book>(viewResult.ViewData.Model);
            var model = viewResult.ViewData.Model as Book;
            Assert.IsInstanceOf((new Book().GetType()), model);
        }
        [TestCase]
        public async Task CreatePost_InvalidModel_ReturnsCreateView()
        {
            //Arrange
            var controller = new BooksController(_fakeLogger.Object, _fakeBookService.Object, _fakeAuthorService.Object, null);
            var httpClient = new HttpClient();

            var _fakeBookModel = new BooksViewModel(); // Invalid (empty) model
            //var jsonConvertedBookModel = JsonConvert.SerializeObject(_fakeBookModel);
            //var httpResult = await httpClient.PostAsync("http://localhost:3000/Book/create", new StringContent(jsonConvertedBookModel, Encoding.UTF8, "application/json"));
            controller.ModelState.AddModelError("BookName", "Required");

            // //Act
            // var result = await controller.Create(_fakeBookModel);

            // //Assert
            // var viewResult = result as ViewResult;
            // Assert.IsTrue(result.GetType() == typeof(ViewResult));
            // Assert.IsTrue(viewResult.ViewData.ModelState.IsValid == false);
            // Assert.IsTrue(viewResult.ViewName == "Index");
        }
        // More Tests
        // 1. Fails with specific inputs (is this actually the logic of the viewmodel?)

        [TestCase]
        public async Task CreatePost_ValidModel_ReturnsRedirectToIndex()
        {
            //Arrange
            var controller = new BooksController(_fakeLogger.Object, _fakeBookService.Object, _fakeAuthorService.Object, null);
            var _fakeBookModel = new BooksViewModel();
            _fakeBookService.Setup(i => i.GetOne(0))
                .ReturnsAsync(new Book());

            //Act
            // var result = await controller.Create(_fakeBookModel);

            // //Assert
            // Assert.IsInstanceOf<RedirectToActionResult>(result);
            // // convert to different format with instance

            // var viewResult = result as RedirectToActionResult;
            // Assert.IsTrue(viewResult.ActionName == "Index");

        }

    }
}
