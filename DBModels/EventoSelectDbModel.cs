namespace JogadorAPI.DBModels
{
    public class EventoSelectDbModel
    {
        public int ID_EVENTO { get; set; }
        public string DESCRICAO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public DateTime HORARIO { get; set; }
        public ushort DURACAO_MINUTOS { get; set; }
        public byte POSICAO { get; set; }
        public ushort CUSTO { get; set; }
        public string? NOME_JOGADOR { get; set; }
    }
}
