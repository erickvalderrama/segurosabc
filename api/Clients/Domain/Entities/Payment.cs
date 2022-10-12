using System;
using System.ComponentModel.DataAnnotations;

namespace api.Clientes.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int IdClient { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
