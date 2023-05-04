using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Entities
{
    public class Facility
    {
        public int FacilityId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
