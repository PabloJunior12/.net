namespace APP1.models
{
    public class Tramite
    {

        public int Id { get; set; }
        public string Asunto { get; set; }

        public int OrigenId { get; set; }
        public int DestinoId { get; set; }
        public string DNI { get; set; }
        public string RazonSocial { get; set; }


    }
}
