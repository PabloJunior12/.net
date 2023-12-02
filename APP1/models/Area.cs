using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APP1.models
{
    public class Area
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Encargado { get; set; }

    }
}
