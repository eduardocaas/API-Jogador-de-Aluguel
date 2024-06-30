namespace JogadorAPI.ViewModels
{
    public struct EventoJogadorViewModel
    {
        public EventoJogadorViewModel(
            int IdEvento,
            string Descricao,
            string Cidade,
            string Bairro,
            DateTime Horario,
            ushort DuracaoMinutos,
            byte Posicao,
            ushort Custo,
            string? NomeUsuario)
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

        public int ID_EVENTO { get; set; }
        public string DESCRICAO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public DateTime HORARIO { get; set; }
        public ushort DURACAO_MINUTOS { get; set; }
        public byte POSICAO { get; set; }
        public ushort CUSTO { get; set; }
        public string NOME_USUARIO { get; set; }
    }
}
