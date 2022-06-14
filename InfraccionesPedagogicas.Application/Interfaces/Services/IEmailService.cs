using InfraccionesPedagogicas.Core.Entities;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public Task SendConfirmationEmail(Asistencia registroAsistencia);
    }
}
