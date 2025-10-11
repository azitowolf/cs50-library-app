using System;
using System.Collections.Generic;
using Library.DomainModels;

namespace Library.Web.Models
{
    public class HomeViewModel
    {
        public List<Book> BookList { get; }

        public HomeViewModel(List<Book> bookList)
        {
            BookList = bookList;
        }

    }
}