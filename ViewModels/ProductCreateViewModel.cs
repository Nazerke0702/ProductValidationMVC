using System.ComponentModel.DataAnnotations;
using ProductValidationMVC.Validation;

namespace ProductValidationMVC.ViewModels;

public sealed class ProductCreateViewModel
{
    [Required(ErrorMessage = "Тауар атауын енгізіңіз")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Тауар атауы 3 пен 100 таңба аралығында болуы керек")]
    [RegularExpression(@"^[A-Za-zА-Яа-яЁёӘәҒғҚқҢңӨөҰұҮүҺһІі0-9 -]+$", ErrorMessage = "Тауар атауына тек әріптер, сандар, бос орын және дефис енгізіңіз")]
    [Display(Name = "Тауар атауы")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Сипаттама 500 таңбадан аспауы керек")]
    [Display(Name = "Сипаттамасы")]
    public string? Description { get; set; }

    [Range(typeof(decimal), "1", "1000000", ErrorMessage = "Баға 1 мен 1 000 000 аралығында болуы керек")]
    [Display(Name = "Бағасы (₸)")]
    public decimal Price { get; set; }

    [Range(1, 10000, ErrorMessage = "Саны 1 мен 10 000 аралығында болуы керек")]
    [Display(Name = "Саны")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Категорияны таңдаңыз")]
    [Display(Name = "Категориясы")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email мекенжайын енгізіңіз")]
    [EmailAddress(ErrorMessage = "Email мекенжайының пішімін тексеріңіз")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email мекенжайын қайта енгізіңіз")]
    [Compare(nameof(Email), ErrorMessage = "Email мекенжайлары сәйкес келмейді")]
    [Display(Name = "Email растау")]
    public string ConfirmEmail { get; set; } = string.Empty;

    [FutureDateNotAllowed(ErrorMessage = "Шығарылған күн болашақта болмауы керек")]
    [DataType(DataType.Date)]
    [Display(Name = "Шығарылған күні")]
    public DateTime? ManufactureDate { get; set; }
}
