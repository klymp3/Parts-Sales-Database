using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Classes.DataBase
{
    [Table("Детали")]
    public class Detail
    {
        [Key]
        public int Id { get; set; }


        [Column("Название")]
        public string Name { get; set; }

        [Column("Цена")]
        public double Price { get; set; }

        [Column("Описание")]
        public string Description { get; set; }


        public Detail() { }
        public Detail(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
