using Microsoft.EntityFrameworkCore;
using TestTaskDAL.Entities;

namespace TestTaskDAL.Context
{
    public class TestTaskContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options)
        {

        }
    }
}
