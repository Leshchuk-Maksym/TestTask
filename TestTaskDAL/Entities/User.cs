using System.ComponentModel.DataAnnotations;

namespace TestTaskDAL.Entities
{
    public class User : IEntity
    {
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
