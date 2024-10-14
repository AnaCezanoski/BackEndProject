using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Domain.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; private set; }

        public string name { get; private set; }

        public string email { get; private set; }

        public string password { get; private set; }

        public User(string name, string email, string password)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.email = email;
            this.password = password;

        }

        public User()
        {
        }
    }
}
