using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Domain.Model.Users
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; private set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public User(string name, string email, string password)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.email = email;
            this.password = password;

        }
        public void Update(string newName, string newEmail, string newPassword)
        {
            if(string.IsNullOrEmpty(newName)) throw new ArgumentNullException(nameof(newName));
            if(string.IsNullOrEmpty(newEmail)) throw new ArgumentNullException(nameof(newEmail));
            if(string.IsNullOrEmpty(newPassword)) throw new ArgumentNullException(nameof(newPassword));

            name = newName;
            email = newEmail;
            password = newPassword;
        }


    }
}
