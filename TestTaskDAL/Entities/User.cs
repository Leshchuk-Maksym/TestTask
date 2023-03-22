using System.ComponentModel.DataAnnotations;

namespace TestTaskDAL.Entities
{
    public class User : IEnitity
    {
        public int UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
