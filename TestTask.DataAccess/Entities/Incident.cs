using System.ComponentModel.DataAnnotations;

namespace TestTask.DataAccess.Entities
{
    public class Incident
    {
        [Key]
        public string IncidentName { get; set; }
        public string Description { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
