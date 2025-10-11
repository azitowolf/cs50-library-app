using Library.DataAccess.Interface;
using Library.DomainModels;
using Library.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Library.UnitTests
{

    [TestFixture]
    public class BookServiceTests
    {
        private BookService _bookService { get; set; }
        private Mock<IBookRepository> _fakeRepository { get; set; }

        [SetUp]
        public void Init()
        {
            //Arrange
            _fakeRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_fakeRepository.Object);
        }

        [TearDown]
        public void Dispose()
        {
            Console.WriteLine("tearing Down");
            // deleting the items from DB if any added
            // generally revert everything to state before tests ran 
        }
        [TestCase]
        public async Task GetAll_NoSearchParameters_Succeeds()
        {
            //Arrange
            var mylist = new List<Book>() { new Book(), new Book() };
            _fakeRepository.Setup(i => i.GetAll(null, null, null, null)).ReturnsAsync(mylist);

            //Act
            var result = await _bookService.GetAll(null, null, null, null);

            //Assert
            Assert.IsTrue(result.Count() == 2);

        }
        [TestCase]
        public async Task GetAll_OneSearchParameter_Succeeds()
        {
            //Arrange
            var mylist = new List<Book>() { new Book() };
            _fakeRepository.Setup(i => i.GetAll("H", null, null, null)).ReturnsAsync(mylist);

            //Act
            var result = await _bookService.GetAll("H", null, null, null);

            //Assert
            Assert.IsTrue(result.Count() == 1);

        }
        [TestCase]
        public async Task GetAll_EmptySearchString_Fails()
        {
            //Arrange
            //Act
            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => _bookService.GetAll("", null, null, null));

        }
    }
}
