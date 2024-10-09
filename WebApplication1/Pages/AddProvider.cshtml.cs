using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebApplication1.Classes.DataBase;
using WebApplication1.Pages.Shared;

namespace WebApplication1.Pages
{
    public class AddProviderModel : _Layout
    {
        public List<Provider> Providers { get; set; }
        private readonly ILogger<IndexModel> _logger;


        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public string address { get; set; }
        [BindProperty]
        public string phoneNumber { get; set; }


        public AddProviderModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var context = new Datab();

            Providers = context.Providers.ToList();
        }


        new public IActionResult OnPost(string action)
        {
            if (action == "addNewProvider")
            {
                Provider provider = new Provider(name, address, phoneNumber);
                if (string.IsNullOrWhiteSpace(name))
                {
                    ViewData["NameError"] = "Фамилия не может состоять только из пробелов";
                }
                else if (string.IsNullOrWhiteSpace(address))
                {
                    ViewData["NameError"] = "Адрес не может состоять только из пробелов";
                }
                else if (Providers.Select(cl => cl.PhoneNumber).ToList().FirstOrDefault(phoneNumber) == phoneNumber)
                {
                    ViewData["NameError"] = "Номер телефона уже занят";
                }
                else
                {
                    using (var context = new Datab())
                    {
                        context.Providers.Add(provider);
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
