namespace JogadorAPI.InputModels
{
    public struct EventoInputModel
    {
        [JsonPropertyName("Id_Usuario")]
        [Required(ErrorMessage = "ID de Usuário é obrigatório")]
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Horário é obrigatório")]
        public DateTime? Horario { get; set; }
        [JsonPropertyName("Duracao")]
        [Required(ErrorMessage = "Duração é obrigatório")]
        public ushort? DuracaoMinutos { get; set; }
        [Required(ErrorMessage = "Posição é obrigatório")]
        public byte? Posicao { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }
    }
}
