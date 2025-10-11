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
    public class AuthorServiceTests
    {
        private AuthorService _authorService { get; set; }
        private Mock<IAuthorRepository> _fakeRepository { get; set; }

        [SetUp]
        public void Init()
        {
            //Arrange
            _fakeRepository = new Mock<IAuthorRepository>();
            _authorService = new AuthorService(_fakeRepository.Object);
        }
        [TearDown]
        public void Dispose()
        {
            Console.WriteLine("tearing Down");
            // deleting the items from DB if any added
            // generally revert everything to state before tests ran 
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Create_AuthorNameNullOrSpace_Fails(string badName) // naming convention : [MethodName][Action][Result]
        {
            //Arrange
            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => _authorService.Create(badName));
        }
        [TestCase("Tiago")]
        [TestCase("Alex")]
        public async Task Create_AuthorNameValid_Succeeds(string goodName)
        {
            //Arrange

            //Act
            await _authorService.Create(goodName);
            //Assert
            _fakeRepository.Verify(i => i.Create(It.IsAny<Author>()), Times.Once);


        }
        [TestCase]
        public async Task GetAll_Succeeds()
        {
            //Arrange
            var mylist = new List<Author>() { new Author(), new Author() };
            _fakeRepository.Setup(i => i.GetAll()).ReturnsAsync(mylist);

            //Act
            var result = await _authorService.GetAll();

            //Assert
            Assert.IsTrue(result.Count() == 2);


        }
    }
}
