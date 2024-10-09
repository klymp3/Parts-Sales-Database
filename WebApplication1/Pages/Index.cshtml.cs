using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Timers;
using System.Transactions;
using System.Xml.Linq;
using WebApplication1.Classes;
using WebApplication1.Classes.DataBase;
using WebApplication1.Pages.Shared;
using static Azure.Core.HttpHeader;

namespace WebApplication1.Pages
{

    public class IndexModel : _Layout
    {
        
        public List<ViewOrder> resultOrders { get; set; }
        public List<Provider> providers { get; set; }
        public List<Detail> details { get; set; }
        public List<Client> clients { get; set; }
        private readonly ILogger<IndexModel> _logger;


        [BindProperty]
        public int colDet { get; set; }

        [BindProperty]
        public int prov { get; set; }

        [BindProperty]
        public int cl { get; set; }

        [BindProperty]
        public int art { get; set; }

        [BindProperty]
        public DateTime crSrDev { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var context = new Datab();
            resultOrders = new List<ViewOrder>();
            providers = new List<Provider>();
            details = new List<Detail>();
            clients = new List<Client>();

            resultOrders = context.Orders.Select(res => new ViewOrder
            {
                Amount = res.Amount,
                NameProvider = context.Providers.First(p => p.Id == res.IdProvider).Name,
                FIOClient = context.Clients.First(c => c.Id == res.IdClient).Surname + " " + context.Clients.First(c => c.Id == res.IdClient).Name,
                VendorСode = res.VendorСode,
                DateOfConclusion = res.DateOfConclusion,
                DeliveryDeadline = res.DeliveryDeadline
            }).ToList();



            providers = context.Providers.ToList();
            details = context.Details.ToList();
            clients = context.Clients.ToList();
        }

        new public IActionResult OnPost(string action)
        {
            if (action == "addNewOrder")
            {
                Order order = new Order(colDet, prov, cl, art, DateTime.Now, crSrDev);
                if (order.Amount <= 0)
                {
                    ViewData["NameError"] = "Количество деталей должно быть больше нуля";
                }
                else if (order.DeliveryDeadline < DateTime.Now)
                {
                    ViewData["NameError"] = "Крайний срок доставки не может быть в прошлом";
                }
                else
                {
                    using (var context = new Datab())
                    {
                        context.Orders.Add(order);
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
