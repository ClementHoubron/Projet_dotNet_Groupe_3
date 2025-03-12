using Projet.AppClient.Service;
using Projet.AppClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Controller
{
    public class ClientController
    {
        private ClientService clientService;
        private ClientView clientView;
        public ClientController(ClientView view)
        {
            clientView = view;
            clientService = new ClientService();
        }

        public async void ShowClients()
        {
            var clients = await clientService.GetClients();
            if (clients.Count == 0)
            {
                Console.WriteLine("Aucun Clients !");
                return;
            }
            clientView.DisplayClientList(clients);
        }
    }
}
