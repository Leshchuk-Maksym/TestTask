using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.DataAccess.Entities
{
    public class Incident
    {

        /// <summary>
        /// Database generated Primary Key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IncidentName { get; set; }

        /// <summary>
        /// Gets or sets the Desciption of the Incident.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of the Accounts for the Incident.
        /// </summary>
        public ICollection<Account> Accounts { get; set; }
    }
}
