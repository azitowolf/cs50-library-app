using System;
using Library.DomainModels;
using System.Collections.Generic;

namespace Library.Web.Models
{
    public class AuthorsViewModel
    {
        public List<Author> Authors { get; set; }

        public AuthorsViewModel(List<Author> authorList)
        {
            Authors = authorList;
        }
    }
}
    