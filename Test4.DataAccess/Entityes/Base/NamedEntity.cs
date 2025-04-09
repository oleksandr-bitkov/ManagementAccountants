using System.ComponentModel.DataAnnotations;

namespace Test4.DataAccess.Entityes.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; } 
    }
}
