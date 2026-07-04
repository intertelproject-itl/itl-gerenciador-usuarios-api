using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.Integration;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class InventarioService(IMongoRepository<InventarioModel> repositoryInventario,
            IMongoRepository<ArmasModel> repositoryArmas,
            IMongoRepository<ArmaduraModel> repositoryArmaduras,
            IMongoRepository<CiberneticasModel> repositoryCiberneticas,
            IMongoRepository<ArmasCiberneticasModel> repositoryArmasCiberneticas,
            IMongoRepository<OutrosModel> repositoryOutros,
            SignalRService signalRService,
            IWebHostEnvironment env) : ServiceBase(signalRService), IInventarioService
    {
        private readonly IWebHostEnvironment _env = env;
        private readonly IMongoRepository<InventarioModel> _repositoryInventario = repositoryInventario;
        private readonly IMongoRepository<ArmasModel> _repositoryArmas = repositoryArmas;
        private readonly IMongoRepository<ArmaduraModel> _repositoryArmaduras = repositoryArmaduras;
        private readonly IMongoRepository<CiberneticasModel> _repositoryCiberneticas = repositoryCiberneticas;
        private readonly IMongoRepository<ArmasCiberneticasModel> _repositoryArmasCiberneticas = repositoryArmasCiberneticas;
        private readonly IMongoRepository<OutrosModel> _repositoryOutros = repositoryOutros;

        public List<InventarioModel> BuscarInventarioPorPersonagem(int idPersonagem)
        {
            var inventario = _repositoryInventario.GetListByChaveAsync("IdPersonagem", idPersonagem.ToString(), CancellationToken.None).Result;
            return inventario;
        }

        public async Task PassarItemAsync(string idItem, bool duplicavel, int idPersonagemOrigem, int idPersonagemDestino, CancellationToken ct)
        {
            var invetarioOrigem = await _repositoryInventario.GetByChaveAsync("idPersonagem", idPersonagemOrigem.ToString(), ct);

            var invetarioDestino = await _repositoryInventario.GetByChaveAsync("idPersonagem", idPersonagemDestino.ToString(), ct);
            if (invetarioDestino == null)
            {
                invetarioDestino = new InventarioModel
                {
                    IdPersonagem = idPersonagemDestino,
                    Armas = new List<ArmasModel>(),
                    Armaduras = new List<ArmaduraModel>(),
                    Ciberneticas = new List<CiberneticasModel>(),
                    ArmasCiberneticas = new List<ArmasCiberneticasModel>(),
                    Outros = new List<OutrosModel>()
                };
                await _repositoryInventario.InsertAsync(invetarioDestino, ct);                
            }

            // Buscar item no inventário do personagem de origem
            var armadura = invetarioOrigem?.Armaduras.FirstOrDefault(a => a.Id == idItem);
            var arma = invetarioOrigem?.Armas.FirstOrDefault(a => a.Id == idItem);
            var cibernetica = invetarioOrigem?.Ciberneticas.FirstOrDefault(c => c.Id == idItem);
            var armaCibernetica = invetarioOrigem?.ArmasCiberneticas.FirstOrDefault(ac => ac.Id == idItem);
            var outroItem = invetarioOrigem?.Outros.FirstOrDefault(o => o.Id == idItem);

            if (armadura == null && arma == null && cibernetica == null && armaCibernetica == null && outroItem == null)
            {
                throw new Exception("Item não encontrado no inventário do personagem de origem.");
            }
            if (armadura != null)
            {
                invetarioDestino?.Armaduras.Add(armadura);
                _repositoryInventario.UpdateAsync(invetarioDestino.Id, invetarioDestino, ct).Wait();
                if (!duplicavel)
                {
                    invetarioOrigem?.Armaduras.Remove(armadura);
                    _repositoryInventario.UpdateAsync(invetarioOrigem.Id, invetarioOrigem, ct).Wait();
                }
            }
            if (arma != null)
            {
                invetarioDestino?.Armas.Add(arma);
                _repositoryInventario.UpdateAsync(invetarioDestino.Id, invetarioDestino, ct).Wait();
                if (!duplicavel)
                {
                    invetarioOrigem?.Armas.Remove(arma);
                    _repositoryInventario.UpdateAsync(invetarioOrigem.Id, invetarioOrigem, ct).Wait();
                }
            }
            if (cibernetica != null)
            {
                invetarioDestino?.Ciberneticas.Add(cibernetica);
                _repositoryInventario.UpdateAsync(invetarioDestino.Id, invetarioDestino, ct).Wait();
                if (!duplicavel)
                {
                    invetarioOrigem?.Ciberneticas.Remove(cibernetica);
                    _repositoryInventario.UpdateAsync(invetarioOrigem.Id, invetarioOrigem, ct).Wait();
                }
            }
            if (armaCibernetica != null)
            {
                invetarioDestino?.ArmasCiberneticas.Add(armaCibernetica);
                _repositoryInventario.UpdateAsync(invetarioDestino.Id, invetarioDestino, ct).Wait();
                if (!duplicavel)
                {
                    invetarioOrigem?.ArmasCiberneticas.Remove(armaCibernetica);
                    _repositoryInventario.UpdateAsync(invetarioOrigem.Id, invetarioOrigem, ct).Wait();
                }
            }
            if (outroItem != null)
            {
                invetarioDestino?.Outros.Add(outroItem);
                _repositoryInventario.UpdateAsync(invetarioDestino.Id, invetarioDestino, ct).Wait();
                if (!duplicavel)
                {
                    invetarioOrigem?.Outros.Remove(outroItem);
                    _repositoryInventario.UpdateAsync(invetarioOrigem.Id, invetarioOrigem, ct).Wait();
                }
            }
            await _signalRService.AtualizarInventario(1, idPersonagemOrigem);
            await _signalRService.AtualizarInventario(1, idPersonagemDestino);
        }

        public async Task InserirNovoItem<T>(T item, IFormFile imagem, CancellationToken ct)
        {
            switch (typeof(T))
            {
                case Type t when t == typeof(ArmasModel):
                    var arma = item as ArmasModel;
                    await _repositoryArmas.InsertAsync(arma, ct);
                    break;
                case Type t when t == typeof(ArmaduraModel):
                    var armadura = item as ArmaduraModel;
                    await _repositoryArmaduras.InsertAsync(armadura, ct);
                    break;
                case Type t when t == typeof(CiberneticasModel):
                    var cibernetica = item as CiberneticasModel;
                    await _repositoryCiberneticas.InsertAsync(cibernetica, ct);
                    break;
                case Type t when t == typeof(ArmasCiberneticasModel):
                    var armaCibernetica = item as ArmasCiberneticasModel;
                    await _repositoryArmasCiberneticas.InsertAsync(armaCibernetica, ct);
                    break;
                case Type t when t == typeof(OutrosModel):
                    var outroItem = item as OutrosModel;
                    if (imagem != null)
                    {
                        var fileName = $"{Guid.NewGuid()}.png";
                        var filePath = Path.Combine(_env.WebRootPath, "uploads", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imagem.CopyToAsync(stream, ct);
                        }
                        outroItem.Imagem = $"/uploads/{fileName}";
                    }
                    await _repositoryOutros.InsertAsync(outroItem, ct);
                    break;
                default:
                    break;
            }            

        }
    }
}
