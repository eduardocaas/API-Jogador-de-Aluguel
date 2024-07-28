using System.Text.Json.Serialization;

namespace JogadorAPI.ViewModels
{
    public struct EventoEscaladoViewModel
    {
        public EventoEscaladoViewModel(
            int IdEvento,
            string Descricao,
            string Cidade,
            string Bairro,
            DateTime Horario,
            int DuracaoMinutos,
            int Posicao,
            int Custo,
            string NomeUsuario)
        {
            ID_EVENTO = IdEvento;
            DESCRICAO = Descricao;
            CIDADE = Cidade;
            BAIRRO = Bairro;
            HORARIO = Horario;
            DURACAO_MINUTOS = DuracaoMinutos;
            POSICAO = Posicao;
            CUSTO = Custo;
            NOME_USUARIO = NomeUsuario;
        }

        [JsonPropertyName("id_evento")]
        public int ID_EVENTO { get; set; }
        public string DESCRICAO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public DateTime HORARIO { get; set; }
        [JsonPropertyName("duracao_minutos")]
        public int DURACAO_MINUTOS { get; set; }
        public int POSICAO { get; set; }
        public int CUSTO { get; set; }
        [JsonPropertyName("nome_usuario")]
        public string NOME_USUARIO { get; set; }
    }
}
