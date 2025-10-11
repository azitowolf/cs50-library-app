using System;
using System.Collections.Generic;

namespace Library.Web.Models
{
    public class SearchResult
    {
        public string Id {get;set;}
        public string Title {get;set;}
        public string ImageUrl {get;set;} 
    }
    public class SearchResultsViewModel
    {
        public Azure.Search.Documents.Models.SearchResults<SearchResult> SearchResults {get;set;}
    }
}