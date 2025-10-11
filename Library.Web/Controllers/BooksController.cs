using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DomainModels;
using Library.Services;
using Library.Services.Interface;
using Library.Web.Models;
using Library.Utils;
using Microsoft.Extensions.Options;


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly AzureStorageConfig storageConfig = null;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ILogger<HomeController> _logger;

        public BooksController(ILogger<HomeController> logger, IBookService bookService, IAuthorService authorService, IOptions<AzureStorageConfig> config)
        {
            _logger = logger;
            _bookService = bookService;
            _authorService = authorService;
            storageConfig = config.Value;
        }

        public async Task<IActionResult> Index(string searchString, string startsWith, DateTime? dateRangeStart, DateTime? dateRangeEnd)
        {
            IEnumerable<Book> books = await _bookService.GetAll(searchString, startsWith, dateRangeStart, dateRangeEnd);
            List<Book> booksFormatted = books.ToList();
            _logger.Log(LogLevel.Debug, "test", new Object { });

            var model = new BooksViewModel(booksFormatted);
            model.PopulateSelectList(_authorService);

            return View(model);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Book book = await _bookService.GetOne(id);
            return View("Book", book);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bookCreateViewModel = new BookCreateViewModel();
            bookCreateViewModel.PopulateSelectList(_authorService);
            return View("Create", bookCreateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                bookViewModel.PopulateSelectList(_authorService);
                return View("Create", bookViewModel);
            }
            // instantiate the helper imageController
            var imageController = new ImagesController(storageConfig, _logger);

            // support for multiple files
            var imageFromUI = bookViewModel.NewBookImageFile;
            List<FormFile> imgList = new List<FormFile>();
            imgList.Add((FormFile)imageFromUI);

            // upload it
            var image = await imageController.Upload(imgList);

            // create a URI to the storage account
            var imageUri = imageController.GetSingleImageUri(imageFromUI.FileName);

            // create the model
            var result = await _bookService.Create(bookViewModel.NewBookName,
                bookViewModel.NewBookAuthorId,
                bookViewModel.NewBookIsAvailable, imageUri);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> GetThumbNails()
        {
            var imageController = new ImagesController(storageConfig, _logger);
            var thumbs = imageController.GetThumbNails(storageConfig);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // get the book
            // do the delete
            Book bookToDelete = await _bookService.DeleteById(id);
            // redirect back to page (refresh to delete)
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Book book = await _bookService.GetOne(id);
            var viewModel = new BookEditViewModel();
            viewModel.BookToEdit = book;
            viewModel.PopulateSelectList(_authorService);
            return View("Edit", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditViewModel bookViewModel, int id)
        {

            _bookService.Edit(bookViewModel.BookToEdit, id);
            
            // TODO add the invalid checks to the thing
            // if (!ModelState.IsValid)
            // {
            //     bookViewModel.PopulateSelectList(_authorService);
            //     return View("Edit", bookViewModel);
            // }
            
            return RedirectToAction("Index");

        }
    }
}
