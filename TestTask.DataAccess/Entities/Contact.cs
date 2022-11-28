using System.ComponentModel.DataAnnotations;

namespace TestTask.DataAccess.Entities
{
    public class Contact
    {
        /// <summary>
        /// Primary key for Contact.
        /// </summary>
        [Key]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets First Name for the Contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name for the Contact.
        /// </summary>
        public string LastName { get; set; }
    }
}
