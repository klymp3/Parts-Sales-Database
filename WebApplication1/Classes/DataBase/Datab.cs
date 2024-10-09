using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;
using Microsoft.Identity.Client;

namespace WebApplication1.Classes.DataBase
{
    public class Datab : DbContext
    {
        //для бд необходимо присоединить файлы из папки и изменить строку подключения к вашему серверу
        string connect = @"Data Source=Klymp3\SQLEXPRESS;Initial Catalog=""Продажа Запчастей"";Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connect);
        }
    }
}
