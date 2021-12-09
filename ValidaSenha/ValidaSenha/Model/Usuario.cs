
using System.Text.Json.Serialization;

namespace ValidaSenha.Model
{
    public class Usuario
    {
        [JsonPropertyName("senha")]
       public string Senha { get; set; }
    }
}
