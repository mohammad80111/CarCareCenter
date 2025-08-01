using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCenter.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string CarName { get; set; }

        [Required]
        public string CarModel { get; set; }


        //forignkey
        public int EmployeeID { get; set; }
        public Employee employee { get; set; }


        //forignkey
        public int RollID { get; set; }
        public Roll  roll { get; set; }



        //forignkey
        public int CarSizeID { get; set; }
        public CarSize  carSize { get; set; }
    }
}
