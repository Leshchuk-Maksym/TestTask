using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskDAL.Entities
{
    public class Answer : IEntity
    {
        public string Body { get; set; }
        public bool IsRight { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
    }
}
