using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementAccountants.DataAccess.Entityes.Base;


namespace ManagementAccountants.DataAccess.Entityes
{
    public class Customer : Person
    {
        public virtual Accountant Accountant { get; set; }
        public virtual ICollection<Report> Reports { get; set; }

        public override string ToString() => $"Кліент [{Name} {Surname} {Patronymic} ({Id})]";
    }
}
