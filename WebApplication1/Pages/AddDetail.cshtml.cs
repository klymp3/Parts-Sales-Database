using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebApplication1.Classes;
using WebApplication1.Classes.DataBase;
using WebApplication1.Pages.Shared;

namespace WebApplication1.Pages
{
    public class AddDetailModel : _Layout
    {
        public List<Detail> Details { get; set; }
        private readonly ILogger<IndexModel> _logger;


        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public double price { get; set; }
        [BindProperty]
        public string description { get; set; }


        public AddDetailModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var context = new Datab();

            Details = context.Details.Select(det => new Detail
            {
                Id = det.Id,
                Name = det.Name,
                Price = det.Price,
                Description = det.Description == "" ? "Описание ещё не задано" : det.Description

            }).ToList();
        }

        new public IActionResult OnPost(string action)
        {
            if (action == "addNewDetail")
            {
                Detail detail = new Detail(name, price, description);
                if (string.IsNullOrWhiteSpace(name))
                {
                    ViewData["NameError"] = "Название детали не указано";
                }
                else if (!name.Any(char.IsLetter))
                {
                    ViewData["NameError"] = "Название детали не может быть только из цифр";
                }
                else if (price <= 0)
                {
                    ViewData["NameError"] = "Цена детали не может быть меньше 0";
                }
                else if (string.IsNullOrWhiteSpace(description) || !description.Any(char.IsLetter))
                {
                    ViewData["NameError"] = "Описание не может быть только из пробелов \n или цифр";
                }
                else if (description != "" && description.Length < 5)
                {
                    ViewData["NameError"] = "Описание не может быть меньше 5 символов";
                }
                else
                {
                    using (var context = new Datab())
                    {
                        context.Details.Add(detail);
                        context.SaveChanges();
                        TempData["ClientAdded"] = true;
                    }
                    return RedirectToPage();
                }
                return Page();
            }
            else return base.OnPost(action);
        }
    }
}
