using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndProject.Domain.Model.Roles
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
        public Role(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
    }
}
