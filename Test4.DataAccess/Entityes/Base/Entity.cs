using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Interfaces;

namespace Test4.DataAccess.Entityes.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
