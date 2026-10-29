
using System;
using System.Linq;

namespace ministyle.Domain
{
    public class AppSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string RazorKey { get; set; } = string.Empty;
        public string RazorSecret { get; set; } = string.Empty;
    }

}
