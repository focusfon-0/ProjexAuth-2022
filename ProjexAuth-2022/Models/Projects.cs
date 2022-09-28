using System.ComponentModel.DataAnnotations;

namespace ProjexAuth_2022.Models
{
    public class Projects
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string projectName { get; set; } = "Voorbeeld projectnaam";
        public string projectDescription { get; set; } = "Voorbeeld projectbeschrijving";
        public string projectOwner { get; set; } = "Voorbeeld opdrachtgever";
        public bool isAvailable { get; set; } = true;
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}
