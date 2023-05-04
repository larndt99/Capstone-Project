using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public String ClientAddress { get; set; }

        [Required(ErrorMessage = "Please enter Client phone number number")]
        [RegularExpression(@"^[0-9]{10}")]
        public long ClientPhoneNumber { get; set; }
        public String ClientPostalCode { get; set; }

      
        public int ClassId{ get; set; }
        public Class? Class { get; set; }


    }
}
