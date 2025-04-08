using Test4.DataAccess.Entityes.Base;

namespace Test4.DataAccess.Entityes
{
    public class Accountant : Person
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
