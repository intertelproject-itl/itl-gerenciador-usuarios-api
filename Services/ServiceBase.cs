using itl_gerenciador_usuarios_api.Infraestructure.Integration;

namespace itl_gerenciador_usuarios_api.Services
{
    public class ServiceBase(SignalRService signalRService)
    {
        public readonly SignalRService _signalRService = signalRService;
    }
}
