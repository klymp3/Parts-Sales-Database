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
                Description = det.Description == "" ? "�������� ��� �� ������" : det.Description

            }).ToList();
        }

        new public IActionResult OnPost(string action)
        {
            if (action == "addNewDetail")
            {
                Detail detail = new Detail(name, price, description);
                if (string.IsNullOrWhiteSpace(name))
                {
                    ViewData["NameError"] = "�������� ������ �� �������";
                }
                else if (!name.Any(char.IsLetter))
                {
                    ViewData["NameError"] = "�������� ������ �� ����� ���� ������ �� ����";
                }
                else if (price <= 0)
                {
                    ViewData["NameError"] = "���� ������ �� ����� ���� ������ 0";
                }
                else if (string.IsNullOrWhiteSpace(description) || !description.Any(char.IsLetter))
                {
                    ViewData["NameError"] = "�������� �� ����� ���� ������ �� �������� \n ��� ����";
                }
                else if (description != "" && description.Length < 5)
                {
                    ViewData["NameError"] = "�������� �� ����� ���� ������ 5 ��������";
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
