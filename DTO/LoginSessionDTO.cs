using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JogadorAPI.DTO
{
    public record struct LoginSessionDTO
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
    }
}
