using System.ComponentModel.DataAnnotations;

namespace CarCenter.Models
{
    public class CarSize
    {
        [Key]
        public int CarSizeID { get; set; }

        [Required]
        public string CarSizeName { get; set; }
    }
}
