using ManagementAccountants.DataAccess.Entityes.Base;

namespace ManagementAccountants.DataAccess.Entityes
{
    public class Accountant : Person
    {
        public virtual ICollection<Customer> Customers { get; set; }

        public override string ToString() => $"Бухгальтер [{Name} {Surname} {Patronymic} ({Id})]";
    }
}
