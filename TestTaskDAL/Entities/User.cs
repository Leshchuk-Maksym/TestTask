using System.ComponentModel.DataAnnotations;
using TestTaskDAL.Enums;

namespace TestTaskDAL.Entities
{
    public class User : IEnitity
    {
        public int UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
    }
}
