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

              

        private async Task<string> SalvarBase64Public(string base64, string pasta, string nomeImagem)
        {

            if (string.IsNullOrWhiteSpace(base64))
                throw new Exception("Base64 não informado.");

            var rootPath = $"{_env.WebRootPath}\\{pasta}";

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

            return caminhoCompleto;
        }
    }
}
