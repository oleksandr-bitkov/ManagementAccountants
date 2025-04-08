using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.DataAccess.Entityes.Base;


namespace Test4.DataAccess.Entityes
{
    public class Customer : Person
    {
        public virtual Accountant Accountant { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
