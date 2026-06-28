using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class LojaNoturnaService(IMongoRepository<ArmasModel> armasRepository, IPersonagemRepository personagemRepository, IMongoRepository<InventarioModel> inventarioRepository,
        IMongoRepository<ArmaduraModel> armadurasRepository, IMongoRepository<ArmasCiberneticasModel> armasCiberneticasRepository,
        IMongoRepository<CiberneticasModel> ciberneticasRepository, IMongoRepository<LojaNoturnaModel> lojaNoturnaRepository) : ILojaNoturnaService
    {
        private readonly IMongoRepository<InventarioModel> _inventarioRepository = inventarioRepository;
        private readonly IPersonagemRepository _personagemRepository = personagemRepository;
        private readonly Random _random = new();
        private readonly IMongoRepository<ArmasModel> _armasRepository = armasRepository;
        private readonly IMongoRepository<ArmaduraModel> _armadurasRepository = armadurasRepository;
        private readonly IMongoRepository<ArmasCiberneticasModel> _armasCiberneticasRepository = armasCiberneticasRepository;
        private readonly IMongoRepository<CiberneticasModel> _ciberneticasRepository = ciberneticasRepository;
        private readonly IMongoRepository<LojaNoturnaModel> _lojaNoturnaRepository = lojaNoturnaRepository;


        private readonly Dictionary<string, int> _pesosPorRaridade = new()
        {
            { "Comum", 60 },
            { "Incomum", 25 },
            { "Raro", 10 },
            { "Epico", 4 },
            { "Lendario", 1 }
        };

        public async Task<LojaNoturnaModel> GerarLojaNoturna(int qtdArmas, int qtdArmaduras, int qtdArmasCiberneticas, int qtdCiberneticas, CancellationToken ct)
        {
            try
            {
                var lojaCache = await _lojaNoturnaRepository.GetFirstOrDefaultAsync(ct);
                if (lojaCache != null)
                    await _lojaNoturnaRepository.DeleteAsync(lojaCache.Id, ct);

                var todosItens = new LojaNoturnaModel();

                todosItens.Armas?.AddRange([.. await _armasRepository.GetAllAsync(ct)]);
                todosItens.Armaduras?.AddRange([.. await _armadurasRepository.GetAllAsync(ct)]);
                todosItens.ArmasCiberneticas?.AddRange([.. await _armasCiberneticasRepository.GetAllAsync(ct)]);
                todosItens.Ciberneticas?.AddRange([.. await _ciberneticasRepository.GetAllAsync(ct)]);
                var banner = SortearItensSemRepetir(todosItens, qtdArmas, qtdArmaduras, qtdArmasCiberneticas, qtdCiberneticas);

                await _lojaNoturnaRepository.InsertAsync(banner, ct);
                return banner;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LojaNoturnaModel> ObterLojaNoturna(CancellationToken ct)
        {
            var lojaCache = await _lojaNoturnaRepository.GetFirstOrDefaultAsync(ct);
            if (lojaCache != null)
                return lojaCache;
            throw new Exception("Nenhuma loja noturna disponível no momento.");
        }

        public async Task ComprarLojaNoturna(string id, decimal valor, int idPersonagem, CancellationToken ct)
        {
            var inventario = await _inventarioRepository.GetByPersoangemIdAsync("IdPersonagem", idPersonagem.ToString(), ct);
            if (inventario == null)
            {
                await _inventarioRepository.InsertAsync(new InventarioModel
                {
                    IdPersonagem = idPersonagem,
                    Armas = new List<ArmasModel>(),
                    Armaduras = new List<ArmaduraModel>(),
                    ArmasCiberneticas = new List<ArmasCiberneticasModel>(),
                    Ciberneticas = new List<CiberneticasModel>()
                }, ct);

                inventario = await _inventarioRepository.GetByPersoangemIdAsync("IdPersonagem", idPersonagem.ToString(), ct);
            }

            var lojaNoturna = await ObterLojaNoturna(ct);

            var arma = lojaNoturna.Armas?.FirstOrDefault(r => r.Id == id);
            if (arma != null)
            {
                await _personagemRepository.ComprarItem(idPersonagem, valor, ct);
                lojaNoturna.Armas?.Remove(arma);                
                await _lojaNoturnaRepository.UpdateAsync(lojaNoturna.Id, lojaNoturna, ct);
                inventario.Armas?.Add(arma);
                await _inventarioRepository.UpdateAsync(inventario.Id, inventario, ct);
                return;
            }

            var armadura = lojaNoturna.Armaduras?.FirstOrDefault(r => r.Id == id);
            if (armadura != null)
            {
                await _personagemRepository.ComprarItem(idPersonagem, valor, ct);
                lojaNoturna.Armaduras?.Remove(armadura);                
                await _lojaNoturnaRepository.UpdateAsync(lojaNoturna.Id, lojaNoturna, ct);
                inventario.Armaduras?.Add(armadura);
                await _inventarioRepository.UpdateAsync(inventario.Id, inventario, ct);
                return;
            }

            var armaCibernetica = lojaNoturna.ArmasCiberneticas?.FirstOrDefault(r => r.Id == id);
            if (armaCibernetica != null)
            {
                await _personagemRepository.ComprarItem(idPersonagem, valor, ct);
                lojaNoturna.ArmasCiberneticas?.Remove(armaCibernetica);                
                await _lojaNoturnaRepository.UpdateAsync(lojaNoturna.Id, lojaNoturna, ct);
                inventario.ArmasCiberneticas?.Add(armaCibernetica);
                await _inventarioRepository.UpdateAsync(inventario.Id, inventario, ct);
                return;
            }

            var cibernetica = lojaNoturna.Ciberneticas?.FirstOrDefault(r => r.Id == id);
            if (cibernetica != null)
            {
                await _personagemRepository.ComprarItem(idPersonagem, valor, ct);
                lojaNoturna.Ciberneticas?.Remove(cibernetica);                
                await _lojaNoturnaRepository.UpdateAsync(lojaNoturna.Id, lojaNoturna, ct);
                inventario.Ciberneticas?.Add(cibernetica);
                await _inventarioRepository.UpdateAsync(inventario.Id, inventario, ct);
                return;
            }
        }

        public async Task<List<ArmasModel>> ObterTodasArmas(CancellationToken ct)
        {
            return [.. await _armasRepository.GetAllAsync(ct)];
        }

        public async Task<List<ArmaduraModel>> ObterTodasArmaduras(CancellationToken ct)
        {
            return [.. await _armadurasRepository.GetAllAsync(ct)];
        }

        public async Task<List<ArmasCiberneticasModel>> ObterTodasArmasCiberneticas(CancellationToken ct)
        {
            return [.. await _armasCiberneticasRepository.GetAllAsync(ct)];
        }

        public async Task<List<CiberneticasModel>> ObterTodasCiberneticas(CancellationToken ct)
        {
            return [.. await _ciberneticasRepository.GetAllAsync(ct)];
        }

        private LojaNoturnaModel SortearItensSemRepetir(
            LojaNoturnaModel itens,
            int qtdArmas, int qtdArmaduras, int qtdArmasCiberneticas, int qtdCiberneticas)
        {
            var resultado = new LojaNoturnaModel();
            var armasDisponiveis = itens.Armas?.ToList();
            var armadurasDisponiveis = itens.Armaduras?.ToList();
            var armasCiberneticasDisponiveis = itens.ArmasCiberneticas?.ToList();
            var ciberneticasDisponiveis = itens.Ciberneticas?.ToList();

            for (int i = 0; i < qtdArmas; i++)
            {
                if (armasDisponiveis.Count == 0)
                    break;

                var itemSorteado = SortearItemPorPeso(armasDisponiveis);

                resultado.Armas?.Add(itemSorteado);

                armasDisponiveis.Remove(itemSorteado);
            }

            for (int i = 0; i < qtdArmaduras; i++)
            {
                if (!armadurasDisponiveis.Any())
                    break;

                var itemSorteado = SortearItemPorPeso(armadurasDisponiveis);

                resultado.Armaduras?.Add(itemSorteado);

                armadurasDisponiveis.Remove(itemSorteado);
            }

            for (int i = 0; i < qtdArmasCiberneticas; i++)
            {
                if (!armasCiberneticasDisponiveis.Any())
                    break;
                var itemSorteado = SortearItemPorPeso(armasCiberneticasDisponiveis);
                resultado.ArmasCiberneticas?.Add(itemSorteado);
                armasCiberneticasDisponiveis.Remove(itemSorteado);
            }

            for (int i = 0; i < qtdCiberneticas; i++)
            {
                if (!ciberneticasDisponiveis.Any())
                    break;
                var itemSorteado = SortearItemPorPeso(ciberneticasDisponiveis);
                resultado.Ciberneticas?.Add(itemSorteado);
                ciberneticasDisponiveis.Remove(itemSorteado);
            }

            return resultado;
        }

        private T SortearItemPorPeso<T>(List<T> model)
        {
            if (typeof(T) == typeof(ArmasModel))
            { 
                var armaModel = model.Cast<ArmasModel>().ToList();
                var pesoTotal = armaModel.Sum(item => _pesosPorRaridade[item.Raridade]);

                var numeroSorteado = _random.Next(1, pesoTotal + 1);
                var acumulado = 0;

                foreach (var item in armaModel)
                {
                    acumulado += _pesosPorRaridade[item.Raridade];

                    if (numeroSorteado <= acumulado)
                        return (T)(object)item;
                }

                return model.Last();
            }

            if (typeof(T) == typeof(ArmaduraModel))
            {
                var armaduraModel = model.Cast<ArmaduraModel>().ToList();
                var pesoTotal = armaduraModel.Sum(item => _pesosPorRaridade[item.Raridade]);

                var numeroSorteado = _random.Next(1, pesoTotal + 1);
                var acumulado = 0;

                foreach (var item in armaduraModel)
                {
                    acumulado += _pesosPorRaridade[item.Raridade];

                    if (numeroSorteado <= acumulado)
                        return (T)(object)item;
                }

                return model.Last();
            }

            if (typeof(T) == typeof(ArmasCiberneticasModel))
            {
                var armasCiberneticasModel = model.Cast<ArmasCiberneticasModel>().ToList();
                var pesoTotal = armasCiberneticasModel.Sum(item => _pesosPorRaridade[item.Raridade]);
                var numeroSorteado = _random.Next(1, pesoTotal + 1);
                var acumulado = 0;
                foreach (var item in armasCiberneticasModel)
                {
                    acumulado += _pesosPorRaridade[item.Raridade];
                    if (numeroSorteado <= acumulado)
                        return (T)(object)item;
                }
                return model.Last();
            }

            if (typeof(T) == typeof(CiberneticasModel))
            {
                var ciberneticasModel = model.Cast<CiberneticasModel>().ToList();
                var pesoTotal = ciberneticasModel.Sum(item => _pesosPorRaridade[item.Raridade]);
                var numeroSorteado = _random.Next(1, pesoTotal + 1);
                var acumulado = 0;
                foreach (var item in ciberneticasModel)
                {
                    acumulado += _pesosPorRaridade[item.Raridade];
                    if (numeroSorteado <= acumulado)
                        return (T)(object)item;
                }
                return model.Last();
            }

            return default;
        }
    }
}