using System.Net.Http.Headers;

namespace FIAP.Library.Domain.Helpers
{
    public static class HttpClientConfiguration
    {
        public static HttpClient CustomerClient()
        {
            var client =  new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:9003"),
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static HttpClient InvoiceClient()
        {
            var client =  new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:9005")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
