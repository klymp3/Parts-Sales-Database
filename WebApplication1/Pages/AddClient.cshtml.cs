using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebApplication1.Classes.DataBase;
using WebApplication1.Pages.Shared;

namespace WebApplication1.Pages
{
    public class AddClientModel : _Layout
    {
        public List<Client> Clients { get; set; }
        private readonly ILogger<IndexModel> _logger;


        [BindProperty]
        public string surname { get; set; }

        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public string address { get; set; }
        [BindProperty]
        public string phoneNumber { get; set; }


        public AddClientModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var context = new Datab();

            Clients = context.Clients.ToList();
        }

        new public IActionResult OnPost(string action)
        {
            if (action == "addNewClient")
            {
                Client client = new Client(surname, name, address, phoneNumber);
                if (string.IsNullOrWhiteSpace(surname))
                {
                    ViewData["NameError"] = "Фамилия не может состоять только из пробелов";
                }
                else if (string.IsNullOrWhiteSpace(name))
                {
                    ViewData["NameError"] = "Имя не может состоять только из пробелов";
                }
                else if (string.IsNullOrWhiteSpace(address))
                {
                    ViewData["NameError"] = "Адрес не может состоять только из пробелов";
                }
                else if (Clients.Select(cl => cl.PhoneNumber).ToList().FirstOrDefault(phoneNumber) == phoneNumber)
                {
                    ViewData["NameError"] = "Номер телефона уже занят";
                }
                else
                {
                    using (var context = new Datab())
                    {
                        context.Clients.Add(client);
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
