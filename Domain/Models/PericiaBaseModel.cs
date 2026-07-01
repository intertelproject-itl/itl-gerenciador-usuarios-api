using Newtonsoft.Json;
using System.Reflection;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public abstract class PericiasBaseModel
    {
        public void AplicarAtributosBase(
            Dictionary<string, List<string>> periciasPorAtributo,
            Dictionary<string, int> valorAtributoPorChave)
        {
            var propriedades = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var grupoAtributo in periciasPorAtributo)
            {
                var chaveAtributo = grupoAtributo.Key;

                if (!valorAtributoPorChave.TryGetValue(chaveAtributo, out var valorAtributo))
                    continue;

                foreach (var nomeJsonPericia in grupoAtributo.Value)
                {
                    var propriedade = propriedades.FirstOrDefault(prop =>
                    {
                        var jsonProperty = prop.GetCustomAttribute<JsonPropertyAttribute>();

                        return string.Equals(
                            jsonProperty?.PropertyName,
                            nomeJsonPericia,
                            StringComparison.OrdinalIgnoreCase
                        );
                    });

                    if (propriedade == null)
                        continue;

                    if (propriedade.PropertyType != typeof(int))
                        continue;

                    propriedade.SetValue(this, valorAtributo);
                }
            }
        }
    }
}
