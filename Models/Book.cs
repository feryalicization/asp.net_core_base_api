using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Genre { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        public int Qty { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}
