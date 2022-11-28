using System.ComponentModel.DataAnnotations;

namespace TestTask.DataAccess.Entities
{
    public class Account
    {

        /// <summary>
        /// Primary key for Account.
        /// </summary>
        /// <value>
        /// The Name of the Account.
        /// </value>
        [Key]
        public string Name { get; set; }

        /// <summary>
        /// Gets of sets the collection of Contacts.
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
