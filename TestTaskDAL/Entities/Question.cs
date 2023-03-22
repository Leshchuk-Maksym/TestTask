using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskDAL.Entities
{
    public class Question : IEntity
    {
        public string Body { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
