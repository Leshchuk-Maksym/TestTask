using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Entities;

namespace TestTask.DataAccess.Context
{
    public class TestTaskContext : DbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Incident> Incidents { get; set; }

        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options)
        { }
    }
}
