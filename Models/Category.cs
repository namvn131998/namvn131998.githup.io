using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}
