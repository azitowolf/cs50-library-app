using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Library.DomainModels;
using Library.Services;
using Library.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Web.Models
{
    public class BookEditViewModel : Book
    {
        public Book BookToEdit { get; set; }

        // Presentation
        public IEnumerable<SelectListItem> AuthorSelect { get; set; }

        public void PopulateSelectList(IAuthorService _authorService)
        {
            var authorList = _authorService.GetAll().Result.ToList();
            AuthorSelect = authorList.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() }).ToList();
        }
    }
}
