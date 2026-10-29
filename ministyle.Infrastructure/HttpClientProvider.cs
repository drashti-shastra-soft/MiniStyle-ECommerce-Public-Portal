using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure
{
    public static class HttpClientProvider
    {
        private static readonly HttpClient _client = new HttpClient();

        public static HttpClient Client => _client;

    }
}
