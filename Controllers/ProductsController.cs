using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductValidationMVC.Data;
using ProductValidationMVC.Models;
using ProductValidationMVC.ViewModels;

namespace ProductValidationMVC.Controllers;

public sealed class ProductsController(ApplicationDbContext db) : Controller
{
    private static readonly string[] Categories = ["Электроника", "Киім", "Үй бұйымдары", "Кеңсе тауарлары", "Азық-түлік", "Басқа"];

    public async Task<IActionResult> Index()
    {
        var products = await db.Products.AsNoTracking().OrderBy(product => product.Name).ToListAsync();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        SetCategories();
        return View(new ProductCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCreateViewModel model)
    {
        if (string.Equals(model.Email?.Trim(), "admin@example.com", StringComparison.OrdinalIgnoreCase))
            ModelState.AddModelError(nameof(model.Email), "Бұл Email мекенжайын пайдалануға болмайды");

        if (!ModelState.IsValid)
        {
            SetCategories();
            return View(model);
        }

        var product = new Product
        {
            Name = model.Name.Trim(),
            Description = string.IsNullOrWhiteSpace(model.Description) ? null : model.Description.Trim(),
            Price = model.Price,
            Quantity = model.Quantity,
            Category = model.Category,
            Email = model.Email!.Trim(),
            CreatedDate = DateTime.UtcNow
        };

        db.Products.Add(product);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Success), new { id = product.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var product = await db.Products.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        return product is null ? NotFound() : View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Success(int id)
    {
        var exists = await db.Products.AsNoTracking().AnyAsync(item => item.Id == id);
        return exists ? View() : NotFound();
    }

    private void SetCategories() => ViewBag.Categories = Categories;
}
