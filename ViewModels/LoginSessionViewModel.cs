using System.Text.Json.Serialization;

namespace JogadorAPI.ViewModels
{
    public record struct LoginSessionViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
    }
}
