using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Classes.DataBase
{
    [Table("Поставщики")]
    public class Provider
    {
        [Key]
        public int Id { get; set; }


        [Column("Название")]
        public string Name { get; set; }

        [Column("Адрес")]
        public string Address { get; set; }

        [Column("Телефон")]
        public string PhoneNumber { get; set; }


        public Provider() { }
        public Provider(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
