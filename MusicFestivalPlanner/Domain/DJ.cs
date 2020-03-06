using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Dj
    {
        public int DjId { get; set; }

        [Display(Name = "Stage Name")]
        [MaxLength(128, ErrorMessage = "Max length for {0} is {1}")]
        [MinLength(2, ErrorMessage = "Min length for {0} is {1}")]
        public string StageName { get; set; }
        
        [Display(Name="First Name")]
        [MaxLength(128, ErrorMessage = "Max length for {0} is {1}")] 
        [MinLength(2, ErrorMessage = "Min length for {0} is {1}")] 
        public string FirstName { get; set; }
        
        
        [Display(Name="Family Name", Prompt="Enter the Family Name here...")]
        [MaxLength(128, ErrorMessage = "Max length for {0} is {1}")] 
        [MinLength(2, ErrorMessage = "Min length for {0} is {1}")] 
        public string LastName { get; set; }
        
        [Display(Name = "Full Name")] public string FirstLastName => FirstName + " " + LastName;
        [Display(Name = "Full Name")] public string LastFirstName => LastName + " " + FirstName;
    }
}