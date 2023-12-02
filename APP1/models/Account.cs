using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP1.models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public bool Active { get; set; }
    }
}
