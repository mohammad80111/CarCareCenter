using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCenter.Models
{
    public class Roll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RollID { get; set; }

        [Required]
        [StringLength(50)]
        public string RollName { get; set; }
    }
}
