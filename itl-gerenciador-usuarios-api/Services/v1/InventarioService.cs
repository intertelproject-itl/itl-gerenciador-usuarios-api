using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class InventarioService(IMongoInventarioRepository<InventarioModel> repository, IWebHostEnvironment env) : IInventarioService
    {
        private readonly IWebHostEnvironment _env = env;
        private readonly IMongoInventarioRepository<InventarioModel> _repository = repository;

        public async Task AdicionarItem(InvetarioRequestDto item, CancellationToken ct)
        {
            await _repository.InsertAsync(new InventarioModel
            {
                Base64 = item.Base64,
                Descricao = item.Descricao,
                IdPersonagem = item.IdPersonagem,
                Nome = item.Nome
            }, ct);

            if (!string.IsNullOrEmpty(item.Base64))
                await SalvarBase64Public(item.Base64, item.Nome);

        }

        public async Task<List<InventarioResponseDTO>> ObterItens(string idPersonagem, CancellationToken ct)
        {
            var itens = await _repository.GetByPersoangemIdAsync("IdPersonagem", idPersonagem, ct);

            return itens == null
                ? throw new Exception("Nenhum item encontrado para o personagem informado.")
                : itens.Select(i => new InventarioResponseDTO
                {
                    IdPersonagem = i.IdPersonagem,
                    Descricao = i.Descricao,
                    Nome = i.Nome
                }).ToList();
        }

        public async Task<string> ObterBase64(string id, CancellationToken ct)
        {
            var item = await _repository.GetBaseByIdAsync(id, ct);
            return item?.Base64 ?? string.Empty;
        }

        private async Task SalvarBase64Public(string base64, string nomeImagem)
        {

            if (string.IsNullOrWhiteSpace(base64))
                throw new Exception("Base64 não informado.");

            var rootPath = _env.WebRootPath;

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            var extensao = ".png";

            if (base64.Contains(","))
            {
                var partes = base64.Split(",");
                var metadata = partes[0];
                base64 = partes[1];

                if (metadata.Contains("image/jpeg"))
                    extensao = ".jpg";
                else if (metadata.Contains("image/png"))
                    extensao = ".png";
                else if (metadata.Contains("image/webp"))
                    extensao = ".webp";
            }

            var bytes = Convert.FromBase64String(base64);

            var nomeArquivo = $"{nomeImagem.Replace(" ", "")}{extensao}";
            var caminhoCompleto = Path.Combine(rootPath, nomeArquivo);

            await System.IO.File.WriteAllBytesAsync(caminhoCompleto, bytes);
        }
    }
}
