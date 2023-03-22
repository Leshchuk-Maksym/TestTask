namespace TestTaskDAL.Entities
{
    public class Test : IEnitity
    {
        public virtual ICollection<Question> Questions { get; set; }
    }
}
