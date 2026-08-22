using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public List<Product> Products { get; set; } = new();

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ProductApi");
    }

    // GET /
    public async Task OnGetAsync()
    {
        Products = await _httpClient.GetFromJsonAsync<List<Product>>(
            "api/products") ?? new List<Product>();
    }

    // POST /?handler=Create
    public async Task<IActionResult> OnPostCreateAsync(
        string name,
        string description,
        decimal price)
    {
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price
        };

        await _httpClient.PostAsJsonAsync(
            "api/products",
            product);

        return RedirectToPage();
    }

    // POST /?handler=Update
    public async Task<IActionResult> OnPostUpdateAsync(
        int id,
        string name,
        string description,
        decimal price)
    {
        var product = new Product
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price
        };

        await _httpClient.PutAsJsonAsync(
            $"api/products/{id}",
            product);

        return RedirectToPage();
    }

    // POST /?handler=Delete
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _httpClient.DeleteAsync(
            $"api/products/{id}");

        return RedirectToPage();
    }
}