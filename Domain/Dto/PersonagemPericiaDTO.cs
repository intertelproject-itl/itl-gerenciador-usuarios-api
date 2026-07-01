using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Dto
{
    public class PersonagemPericiaDTO
    {
        public PericiasArmasModel PericiasArmas { get; set; } = new PericiasArmasModel();
        public PericiasAtencaoModel PericiasAtencao { get; set; } = new PericiasAtencaoModel();
        public PericiasConducaoModel PericiasConducao { get; set; } = new PericiasConducaoModel();        
        public PericiasCorporaisModel PericiasCorporais { get; set; } = new PericiasCorporaisModel();
        public PericiasEducacaoModel PericiasEducacao { get; set; } = new PericiasEducacaoModel();
        public PericiasLutaModel PericiasLuta { get; set; } = new PericiasLutaModel();
        public PericiasPerformanceModel PericiasPerformance { get; set; } = new PericiasPerformanceModel();
        public PericiasSociaisModel PericiasSociais { get; set; } = new PericiasSociaisModel();
        public PericiasTecnicasModel PericiasTecnicas { get; set; } = new PericiasTecnicasModel();
    }
}