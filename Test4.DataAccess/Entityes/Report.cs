using Test4.DataAccess.Entityes.Base;

namespace Test4.DataAccess.Entityes
{
    public class Report : NamedEntity
    {
        public virtual ICollection<Customer> Customers { get; set; }
    } 
}
