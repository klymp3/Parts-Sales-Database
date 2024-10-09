using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Classes.DataBase
{
    [Table("Заказы")]
    public class Order
    {
        [Key]
        public int Id { get; set; }


        [Column("Количество деталей")]
        public int Amount { get; set; }

        [Column("ID поставщика")]
        public int IdProvider { get; set; }

        [Column("ID клиента")]
        public int IdClient { get; set; }

        [Column("Артикул")]
        public int VendorСode { get; set; }

        [Column("Дата заключения")]
        public DateTime DateOfConclusion { get; set; }

        [Column("Крайний срок доставки")]
        public DateTime DeliveryDeadline { get; set; }


        public Order() { }
        public Order(int amount, int idProvider, int idClient, int vendorСode, DateTime dateOfConclusion, DateTime deliveryDeadline)
        {
            Amount = amount;
            IdProvider = idProvider;
            IdClient = idClient;
            VendorСode = vendorСode;
            DateOfConclusion = dateOfConclusion;
            DeliveryDeadline = deliveryDeadline;
        }
    }
}
