using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Azure.Search.Documents;
using Microsoft.Extensions.Configuration;
using Azure.Search.Documents.Models;
using Library.DomainModels;
using Library.Web.Models;
using Azure;

namespace Library.Web.Controllers
{
    public class Book2
    {
        public string Id {get;set;}
        public string Title {get;set;}
        public string ImageUrl {get;set;} 
    }
    public class SearchController : Controller
    {
        private ILogger _logger;
        public IConfiguration _configuration { get; }
        public SearchController(IConfiguration configuration, ILogger<SearchController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        private static SearchClient CreateSearchClientForQueries(string indexName, IConfiguration configuration)
        { 
            // Get the relevant keys + info from config
            string searchServiceEndPoint = configuration["SearchServiceEndPoint"];
            string queryApiKey = configuration["SearchServiceQueryApiKey"];

            SearchClient searchClient = new SearchClient(new Uri(searchServiceEndPoint), indexName, new AzureKeyCredential(queryApiKey));
            return searchClient;
        }
 
        public async Task<IActionResult> Index()
        {
            try 
            {
                _logger.LogInformation("Searching for all entries");
                SearchOptions options;
                SearchResults<SearchResult> results;


                Console.WriteLine("searching for all books:\n");
                var searchClient = CreateSearchClientForQueries("azuresql-index", _configuration);
                options = new SearchOptions();
                options.Select.Add("Title");
                options.Select.Add("Id");
                options.Select.Add("ImageUrl");

                results = searchClient.Search<SearchResult>("*", options);
                
                var viewModel = new SearchResultsViewModel();
                
                viewModel.SearchResults = results;
                
                return View("Index", results.GetResults().ToList());

            }
            catch(Exception exception)
            {
                _logger.LogError(exception.ToString());
                var viewModel = new ErrorViewModel();
                viewModel.RequestId = "";
                viewModel.RequestId = "";
                return View("Error", exception);
            }

        }
    }
}
