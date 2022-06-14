using Microsoft.AspNetCore.Identity;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Usuario: IdentityUser
    {
        
        public string Nombre { get; set; }  
        
        public virtual ICollection<Sala> Salas { get; set; }
    }
}
