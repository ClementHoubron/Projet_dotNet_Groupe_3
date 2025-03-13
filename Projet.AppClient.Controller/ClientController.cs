using Azure.Core.GeoJson;
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

        public async Task<int> AddClientParticulier(ClientParticulierDto cliDto)
        {
            var existingCli = await clientService.GetByNomPrenom(cliDto.Nom, cliDto.Prenom);
            if (existingCli != null)
            {
                Console.WriteLine($" Le client existe déjà.");
                return 0;
            }

            int result = await clientService.AddClientParticulier(cliDto);
            if (result == 0)
            {
                Console.WriteLine("Erreur lors de l'ajout du client !");

            }

            Console.WriteLine("Client ajouté avec succès !");
            return result;


        }


        public async Task<int> AddClientProfessionnel(ClientProfessionnelDto cliDto)
        {
            var existingCli = await clientService.GetByNomSiret(cliDto.Nom, cliDto.Siret);
            if (existingCli != null)
            {
                Console.WriteLine($" Le client existe déjà.");
                return 0;
            }

            int result = await clientService.AddClientProfessionnel(cliDto);
            if (result == 0)
            {
                Console.WriteLine("Erreur lors de l'ajout du client !");

            }

            Console.WriteLine("Client ajouté avec succès !");
            return result;


        }

        public async void GetClientParticulier(string nom, string prenom)
        {
            ClientParticulierDto cliDto = await clientService.GetByNomPrenom(nom, prenom);
            if (cliDto == null)
            {
                Console.WriteLine("Pas de client connu : " + nom + " " + prenom);
            }
            else
                clientView.DisplayClient(cliDto);
        }

        public async void GetClientProfessionnel(string nom, string siret)
        {
            ClientProfessionnelDto cliDto = await clientService.GetByNomSiret(nom, siret);
            if (cliDto == null)
            {
                Console.WriteLine("Pas de client connu : " + nom + " " + siret);
            }
            else
                clientView.DisplayClient(cliDto);
        }
    }
}
