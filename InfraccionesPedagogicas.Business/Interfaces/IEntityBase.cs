using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Interfaces
{
    public  interface IEntityBase<TKey>
    {
        TKey Id { get; set; }   
    }
}
