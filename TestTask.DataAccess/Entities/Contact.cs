using System.ComponentModel.DataAnnotations;

namespace TestTask.DataAccess.Entities
{
    public class Contact
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
