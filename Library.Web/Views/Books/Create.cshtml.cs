using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;
using Library.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Web.Models
{
    public class BookCreateViewModel
    {
        [Display(Name = "The book you want to add ~")]
        [Required(ErrorMessage = "Book name is required!")]
        [MinLength(3)]
        public string NewBookName { get; set; }

        [Display(Name = "The author of that book")]
        [Required(ErrorMessage = "Author name is required!")]
        public int NewBookAuthorId { get; set; }

        [Display(Name = "Is this book available?")]
        public bool NewBookIsAvailable { get; set; }

        [Required(ErrorMessage = "Image is required!")]
        public IFormFile NewBookImageFile { get; set; }
        
        // display only
        public IEnumerable<SelectListItem> AuthorSelect { get; set; }

        public void PopulateSelectList(IAuthorService _authorService)
        {
            var authorList = _authorService.GetAll().Result.ToList();
            AuthorSelect = authorList.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() }).ToList();
        }
        public BookCreateViewModel(IAuthorService authorService)
        {
            PopulateSelectList(authorService);
        }

        public BookCreateViewModel()
        {
            
        }
    }
}
