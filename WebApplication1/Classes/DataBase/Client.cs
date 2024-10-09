using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Classes.DataBase
{
    [Table("Клиенты")]
    public class Client
    {
        [Key]
        public int Id { get; set; }


        [Column("Фамилия")]
        public string Surname { get; set; }

        [Column("Имя")]
        public string Name { get; set; }

        [Column("Адрес")]
        public string Address { get; set; }

        [Column("Телефон")]
        public string PhoneNumber { get; set; }


        public Client() { }
        public Client(string surname, string name, string address, string phoneNumber)
        {
            Surname = surname;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
