using Projet.AppClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.View
{
    public class ClientView
    {
        public void DisplayClient(ClientDto cli)
        {
            if (cli != null)
            {
                Console.WriteLine(cli.ToString());
            }
            else
                Console.WriteLine("Pas de client correspondant.");
        }

        public void DisplayClientList(List<ClientDto> clients)
        {
            foreach (var client in clients)
            {
                DisplayClient(client);
            }
        }
    }
}
