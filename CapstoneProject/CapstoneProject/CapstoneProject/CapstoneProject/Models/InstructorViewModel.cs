using CapstoneProject.Entities;
namespace CapstoneProject.Models
{
    public class InstructorViewModel
    {
        public List<Instructor>? InstructorId { get; set; }
        public Instructor ActiveInstructor { get; set; }

        public int ClassId { get; set; }

    }
}
