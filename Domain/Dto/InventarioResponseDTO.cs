namespace itl_gerenciador_usuarios_api.Domain.Dto
{
    public class InventarioResponseDTO
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string CaminhoImagem { get; set; } = string.Empty;
    }
}
