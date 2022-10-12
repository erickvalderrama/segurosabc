using api.Clientes.Domain.DTO;
using api.Clients.Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace api.Clientes.Domain.Services
{
    public class ClientServiceImpl:ClientService
    {
        private readonly ClientRepository _ClientRepository;
        public ClientServiceImpl(ClientRepository ClientRepository)
        {
            _ClientRepository = ClientRepository ?? throw new ArgumentNullException(nameof(ClientRepository));
        }
        public List<ClientPayment> GetClientPayments(string identification) { 
            List<ClientPayment> paymentList = new List<ClientPayment>();

            paymentList = _ClientRepository.GetClientPayments(identification);
            return paymentList;
        }
    }
}
