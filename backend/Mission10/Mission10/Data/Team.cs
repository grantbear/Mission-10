using System.ComponentModel.DataAnnotations;

namespace Mission10.Data
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        // Navigation Property
        public List<Bowler> Bowlers { get; set; }
    }
}
