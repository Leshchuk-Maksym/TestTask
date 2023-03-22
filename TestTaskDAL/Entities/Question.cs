namespace TestTaskDAL.Entities
{
    public class Question : IEntity
    {
        public string Body { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public int RightAnswerId { get; set; }
    }
}
