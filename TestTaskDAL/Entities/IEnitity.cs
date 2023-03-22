using System.ComponentModel.DataAnnotations;

namespace TestTaskDAL.Entities
{
    public abstract class IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
