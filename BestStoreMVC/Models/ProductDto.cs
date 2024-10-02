using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class ProductDto
    {

        [Required, MaxLength(100)]
        public string NroductName { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";

        [Required, MaxLength(100)]
        public string Category { get; set; } = "";

        [Required]
        public decimal Price { get; set; }

        public IFormFile? ImageFile { get; set; }

    }
}
