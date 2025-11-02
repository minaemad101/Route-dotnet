using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name required")]
        [MaxLength(3,ErrorMessage ="max length is 3")]
        public string Name { get; set; }
    }
}
