using System;
using System.ComponentModel.DataAnnotations;

namespace PTC.Data
{
    public class TrainingProduct
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "{0} must be filled in")]
        [Display(Description = "Product Name")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "{0} must be greater than {2} characters and less than {1}")]
        public string ProductName { get; set; }
        [Range(typeof(DateTime), "1/1/2000", "12/31/2020", ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Description = "Introduction Date")]
        public DateTime IntroductionDate { get; set; }
        [Required(ErrorMessage = "{0} must be filled in")]
        [Display(Description = "URL")]
        [StringLength(2000, MinimumLength = 5, ErrorMessage = "{0} must be greater than {2} characters and less than {1}")]
        public string Url { get; set; }
        [Display(Description = "Price")]
        [Range(1, 9999, ErrorMessage = "{0} must be greater than {2} characters and less than {1}")]
        public decimal Price { get; set; }
    }
}
