using System;
using System.ComponentModel.DataAnnotations;

namespace Chap08_04.Models
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Product Name shoud not be empty.")]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}