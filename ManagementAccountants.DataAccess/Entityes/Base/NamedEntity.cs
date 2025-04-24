using System.ComponentModel.DataAnnotations;

namespace ManagementAccountants.DataAccess.Entityes.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; } 
    }
}
