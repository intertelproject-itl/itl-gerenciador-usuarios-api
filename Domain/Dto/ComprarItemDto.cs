namespace itl_gerenciador_usuarios_api.Domain.Dto
{
    public class ComprarItemDto
    {
        public string? IdMongo { get; set; }
        public string? Categoria { get; set; }
        public long Valor { get; set; }
        public int IdPersonagem { get; set; }
    }
}
