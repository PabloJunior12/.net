namespace APP1.models
{
    public class Historico
    {

        public int Id { get; set; }
        public int TramiteId { get; set; }
        public string RazonSocial { get; set; }
        public int OrigenId { get; set; }
        public int DestinoId { get; set; }
        public string Asunto { get; set; }
    }
}
