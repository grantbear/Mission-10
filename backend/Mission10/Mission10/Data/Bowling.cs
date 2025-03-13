using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission10.Data
{
    public class Bowler
    {
        [Key]
        public int BowlerID { get; set; }

        [Required]
        public string BowlerLastName { get; set; }

        [Required]
        public string BowlerFirstName { get; set; }

        public string BowlerMiddleInit {  get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerPhoneNumber { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }
        public string BowlerZip { get; set; }

        // Foreign Key
        public int TeamID { get; set; }

        // Navigation Property
        [ForeignKey("TeamID")]
        public Team Team { get; set; }
    }
}

