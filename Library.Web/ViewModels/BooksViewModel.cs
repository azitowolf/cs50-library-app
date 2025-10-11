using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Library.DomainModels;
using Library.Services.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Web.Models
{
    public class BooksViewModel
    {
        public BooksViewModel()
        {
        }
        public BooksViewModel(List<Book> bookList)
        {
            Books = bookList;
        }

        public List<Book> Books { get; set; }

        [Display(Name = "The book you want to add ~")]
        [Required(ErrorMessage = "Book name is required!")]
        public string NewBookName { get; set; }

        [Display(Name = "The author of that book")]
        [Required(ErrorMessage = "Author name is required!")]
        public int NewBookAuthorId { get; set; }

        [Display(Name = "Is this book available?")]
        public bool NewBookIsAvailable { get; set; }

        // IEnumerable for dropdown
        public IEnumerable<SelectListItem> AuthorSelect { get; set; }

        public void PopulateSelectList(IAuthorService _authorService)
        {
            var authorList = _authorService.GetAll().Result.ToList();

            // when you have a collection, linq methods will have  lambda
            // lists are IEnumerables (any collection)
            AuthorSelect = authorList.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() }).ToList();
        }
    }
}
