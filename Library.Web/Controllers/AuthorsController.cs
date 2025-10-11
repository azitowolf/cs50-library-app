using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.DataAccess.Interface;
using Library.Web.Models;
using Library.DomainModels;
using Library.Services.Interface;
using Library.Web.Views.Authors;
using Microsoft.Extensions.Configuration;

namespace Library.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IConfiguration _config;

        public AuthorsController(IAuthorRepository authorRepository, IAuthorService authorService, IConfiguration configuration)
        {
            _authorService = authorService;
            _config = configuration;
        }
        public IActionResult Index()
        {
            var authorList = _authorService.GetAll();
            List<Author> authorListFormatted = authorList.Result.ToList();
            var model = new AuthorsViewModel(authorListFormatted);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string authorName)
        {
            await _authorService.Create(authorName);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int Id)
        {
            Author authorModel = await _authorService.GetOne(Id);
            return View("Author", authorModel);
        }

    }
}
