﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Exceptions
{
    public  class ForbiddenAccessException :Exception
    {
        public ForbiddenAccessException()
        {

        }
        public ForbiddenAccessException(string message)
         : base(message)
        {

        }
    }
}
