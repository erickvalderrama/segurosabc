using api.Clientes.Domain.DTO;
using api.Clientes.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly ClientService _clientService;

        public ClientsController(ILogger<ClientsController> logger, ClientService clientService)
        {
            this._logger = logger;
            _clientService = clientService;
        }

        [HttpGet]
        [Route("payments")]
        public ActionResult<List<ClientPayment>> GetClientPayments(string identification)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var datos = _clientService.GetClientPayments(identification);

                    if (datos == null)
                    {
                        return NotFound();
                    }
                    return datos;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error in GetClientPayments: " + ex.Message);
                throw new Exception("Error in GetClientPayments: " + ex.Message);
            }
        }
    }
}
