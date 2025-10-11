using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Library.Web.Views.Authors
{
    public class AuthorModel : PageModel
    {
        private IConfiguration configuration;
        public string Message { get; set; }

        public AuthorModel(IConfiguration config)
        {
            Message = "helloworld";
            configuration = config;
        }

    }
}
