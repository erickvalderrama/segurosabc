using api.Clientes.Domain.DTO;
using System.Collections.Generic;

namespace api.Clientes.Domain.Services
{
    public interface ClientService
    {
        public List<ClientPayment> GetClientPayments(string identification);
    }
}
