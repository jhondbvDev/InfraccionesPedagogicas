﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Interfaces
{
    public interface IPaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
