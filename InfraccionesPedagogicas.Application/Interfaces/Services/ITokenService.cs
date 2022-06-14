using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface ITokenService
    {
        public  string GenerateJWTToken(string userId, string userName, IList<string> roles );
    }
}
