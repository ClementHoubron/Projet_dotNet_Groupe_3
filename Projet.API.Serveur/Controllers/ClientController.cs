using Microsoft.AspNetCore.Mvc;
using Projet.AppClient.Service;

namespace Projet.API.Serveur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {

        private readonly ClientService clientService;

        public ClientController()
        {
            this.clientService = new ClientService();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetProducts()
        {
            var clients = await clientService.GetClients();
            return Ok(clients);
        }

    }
}
