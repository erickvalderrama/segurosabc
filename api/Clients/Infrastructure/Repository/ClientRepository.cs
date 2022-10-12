using api.Clientes.Domain.DTO;
using api.Shared.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace api.Clients.Infrastructure.Repository
{
    public class ClientRepository
    {
        private AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<ClientPayment> GetClientPayments(string identification)
        {
            List<ClientPayment> objData;
            try
            {
                objData = _context.ClientPayment.FromSqlRaw("[dbo].[sp_GetClientPayments] {0}", identification).ToList();

                return objData;

            }
            catch (Exception ex)
            {
                throw new Exception("Error repository - GetClientPayments: " + ex.Message);
            }
        }
    }
}
