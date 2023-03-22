﻿namespace TestTaskDAL.Entities
{
    public class Test : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
