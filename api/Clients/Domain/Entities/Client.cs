using System.ComponentModel.DataAnnotations;

namespace api.Clientes.Domain.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Identification { get; set; }
        public string PIN { get; set; }
    }
}
