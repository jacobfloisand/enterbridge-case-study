using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildingSuppiesWebApp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ProductModel(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [BindProperty]
        public string Search { get; set; }

        public List<ProductDto> Results { get; set; } = new();

        public async Task OnPost()
        {
            var url = $"https://api.casestudy.enterbridge.com/api/products?name={Search}&PageSize=10";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var data = JsonSerializer.Deserialize<ProductResponse>(json, options);

                Results = data?.Items ?? new List<ProductDto>();
            }
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public string Category { get; set; }
    }

    public class ProductResponse
    {
        public List<ProductDto> Items { get; set; }
    }
}