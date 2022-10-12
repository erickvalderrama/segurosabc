using System;
using System.ComponentModel.DataAnnotations;

namespace api.Clientes.Domain.DTO
{
    public class ClientPayment
    {
        [Key]
        public int IdPayment { get; set; }
        public string FullName { get; set; }
        public string Identification { get; set; }
        public string PIN { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
