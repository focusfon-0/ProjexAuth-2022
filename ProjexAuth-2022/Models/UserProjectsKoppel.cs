using System.ComponentModel.DataAnnotations;

namespace ProjexAuth_2022.Models
{
    public class UserProjectsKoppel
    {
        [Key] [Required]
        public AspNetUser user { get; set; }

        [Key] [Required]
        public Projects project { get; set; }
    }
}
