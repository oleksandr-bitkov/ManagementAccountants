using ManagementAccountants.DataAccess.Entityes.Base;

namespace ManagementAccountants.DataAccess.Entityes
{
    public class Report : NamedEntity
    {
        public virtual ICollection<Customer> Customers { get; set; }

        public override string ToString() => $"Звіт [{Name} ({Id})]";
    } 
}
