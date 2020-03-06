using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Role
    {
        public int RoleId { get; set; }
        
        [Display(Name="Name of Perfomer Role")]
        [MaxLength(128, ErrorMessage = "Max length for {0} is {1}")] 
        [MinLength(2, ErrorMessage = "Min length for {0} is {1}")] 
        public string RoleName { get; set; } = default!;
        
        public ICollection<PerformerSong>? PerformerSongs { get; set; }
    }
}