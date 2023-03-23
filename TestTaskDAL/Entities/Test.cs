using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskDAL.Entities
{
    public class Test : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BestScore { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
