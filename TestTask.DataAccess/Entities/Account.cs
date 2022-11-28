using System.ComponentModel.DataAnnotations;

namespace TestTask.DataAccess.Entities
{
    public class Account
    {
        [Key]
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
