using System.Text.Json.Serialization;

namespace JogadorAPI.ViewModels
{
    public struct EventoCreateViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public DateTime Horario { get; set; }
        [JsonPropertyName("Duracao")]
        public ushort DuracaoMinutos { get; set; }
        public byte Posicao { get; set; }
        public ushort Custo { get; set; }
        [JsonPropertyName("Nome_Jogador")]
        public string? NomeJogador { get; set; }
    }
}
