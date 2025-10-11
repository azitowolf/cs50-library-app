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
using Library.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Library.Utils;

namespace Library.UnitTests
{
    // TODO : add the entities to the results view, not local
    [TestFixture]
    public class BookRepositoryTests
    {
        public LibraryDbContext libraryDbContext { get; set; }

        [SetUp]
        public void Init()
        {
            // TODO: set up an in - memory or JSON Mock for the database 
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryLibraryDB")
                .Options;

            libraryDbContext = new LibraryDbContext(options);
            libraryDbContext.Database.EnsureCreated();
            // IQueryable : the query object (not yet executed) 
        }

        [TearDown]
        public void TearDown()
        {
            // deleting the items from DB if any added
            // generally revert everything to state before tests ran
            libraryDbContext.Database.EnsureDeleted();
            libraryDbContext.Dispose();
        }
        [TestCase]
        public async Task Create_Book_Succeeds()
        {
            //Arrange

            var _testBook = new Book();
            libraryDbContext.Books.Add(_testBook);

            //Act
            var result = await libraryDbContext.Books.FindAsync(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(_testBook.Id > 0);
        }
        [TestCase]
        public async Task Create_Book_AddsRecordsIncrementally()
        {
            //Arrange
            libraryDbContext.Books.RemoveRange(libraryDbContext.Books);
            libraryDbContext.SaveChanges();

            var _testBook = new Book();
            var _testBook2 = new Book();
            libraryDbContext.Books.Add(_testBook);
            libraryDbContext.Books.Add(_testBook2);
            libraryDbContext.SaveChanges();

            //Act
            var result = await libraryDbContext.Books.FindAsync(1);
            var result2 = await libraryDbContext.Books.FindAsync(2);
            var outOfScopeResult = await libraryDbContext.Books.FindAsync(3);

            //Assert
            Assert.IsTrue(result.Id > 0);
            Assert.IsNull(outOfScopeResult);
        }
        [TestCase]
        public async Task Create_Author_Succeeds()
        {
            //Arrange
            var _testAuthor = new Author();
            libraryDbContext.Authors.Add(_testAuthor);

            //Act
            var result = await libraryDbContext.Authors.FindAsync(1);

            //Assert
            Assert.IsTrue(result.Id > 0);
        }
        //[TestCase]
        //public async Task Create_InValidParams_Fails()
        //{
        //    //Arrange
        //    var _testBook = new Book();
        //    var repository = new BookRepository(libraryDbContext);

        //    //Act
        //    var result = await repository.Create(_testBook);

        //    //Assert
        //    Assert.IsInstanceOf(new Book().GetType(), result);
        //    Assert.IsTrue(result.Id > 0);
        //}

        // CHECK DEFAULT VALUE ADDED
        // If there is an invalid object given
        // plan unit tests for my db
        // IE tests for the DB schema
        // 

        //[TestCase]
        //public async Task Create_InValidParams_Fails()
        //{
        //    //Arrange
        //    var _testBook = new Book();
        //    var repository = new BookRepository(libraryDbContext);

        //    //Act
        //    var result = await repository.Create(_testBook);

        //    //Assert
        //    Assert.IsInstanceOf(new Book().GetType(), result);
        //    Assert.IsTrue(result.Id > 0);
        //}

    }
}
