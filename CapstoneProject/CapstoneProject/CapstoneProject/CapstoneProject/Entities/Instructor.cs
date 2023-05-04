namespace CapstoneProject.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string InstructorAddress { get; set; }
        public string InstructorPostalCode { get; set; }
        public long InstructorPhoneNumber { get; set; }
        public int ClassId { get; set; }
        public Class? Class { get; set; }
        
    }
}
