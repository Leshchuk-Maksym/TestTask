namespace TestTaskDAL.Entities
{
    public class Answer : IEntity
    {
        public string Body { get; set; }
        public bool IsRight { get; set; }
    }
}
