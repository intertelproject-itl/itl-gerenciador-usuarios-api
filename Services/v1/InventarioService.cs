using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class InventarioService(IMongoRepository<InventarioModel> repositoryInventario, IWebHostEnvironment env) : IInventarioService
    {
        private readonly IWebHostEnvironment _env = env;
        private readonly IMongoRepository<InventarioModel> _repositoryInventario = repositoryInventario;

        public List<InventarioModel> BuscarInventarioPorPersonagem(int idPersonagem)
        {
            var inventario = _repositoryInventario.GetListByChaveAsync("IdPersonagem", idPersonagem.ToString(), CancellationToken.None).Result;
            return inventario;
        }
    }
}
