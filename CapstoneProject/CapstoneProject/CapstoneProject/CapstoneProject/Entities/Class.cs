using System.ComponentModel.DataAnnotations;
namespace CapstoneProject.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int ClassPrice { get; set; }
        public int InstructorId { get; set; }
        // public Instructor? Instructor { get; set; }
        //public int ClientId { get; set; }
        //public Client? Client { get; set; }

        public ICollection<Client>? Clients { get; set; }
        public ICollection<Instructor>? Instructors { get; set; } // added property

    }
}
