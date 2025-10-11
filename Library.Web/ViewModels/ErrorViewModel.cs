using System;

namespace Library.Web.Models
{
    public class ErrorViewModel : System.Exception
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
