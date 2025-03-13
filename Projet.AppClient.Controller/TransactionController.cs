using Projet.AppClient.Data.Entities;
using Projet.AppClient.Service;
using Projet.AppClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet.AppClient.Controller
{
    public class TransactionController
    {
        private TransactionBancaireService transactionService;
        private CompteBancaireService compteBancaireService;
        private TransactionView transactionView;

        public TransactionController(TransactionView view)
        {
            transactionView = view;
            transactionService = new TransactionBancaireService();
            compteBancaireService = new CompteBancaireService();
        }

        public async void ShowTransactions()
        {
            var transList = await transactionService.GetAllTransactions();
            if (transList.Count == 0)
            {
                Console.WriteLine("Aucune Transaction !");
                return;
            }

            transactionView.DisplayTransactionList(transList);
        }
        public async void ShowTransactionsByNumCompte(string numCompte)
        {
            var transList = await transactionService.GetAllTransactionsByNumCompte(numCompte);
            if (transList.Count == 0)
            {
                Console.WriteLine("Aucune Transaction !");
                return;
            }

            transactionView.DisplayTransactionList(transList);
        }
        public async void ShowTransactionsByNumCarte(string numCarte)
        {
            var transList = await transactionService.GetAllTransactionsByNumCarte(numCarte);
            if (transList.Count == 0)
            {
                Console.WriteLine("Aucune Transaction !");
                return;
            }

            transactionView.DisplayTransactionList(transList);
        }

        public async void ImportTransactionServeur()
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Projet.Api.Serveur\GeneratedFiles");
            string searchPattern = "transactions_validated_*.json";
            List<string> latestsFile = Directory.GetFiles(directoryPath, searchPattern)
                                         .OrderByDescending(f => f)
                                         .ToList();
            foreach (string file in latestsFile)
            {
                var json = await System.IO.File.ReadAllTextAsync(file);
                var transactions = JsonSerializer.Deserialize<List<TransactionImportDto>>(json);
                var transResult = await transactionService.ImportTransactions(transactions);
                Console.WriteLine(transResult.ToString());
            }
            foreach (string file in latestsFile)
            {
                try
                {
                    System.IO.File.Delete(file);
                    Console.WriteLine($"[INFO] Fichier supprimé après traitement : {file}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERREUR] Impossible de supprimer le fichier {file} : {ex.Message}");
                }
            }

        }

        public async void ExportTransactionByNumCompteForPeriod(string numCompte, DateTime before, DateTime after)
        {
            var transList = await transactionService.GetAllTransactionsByNumCompteForPeriod(numCompte, before, after);
            if (transList.Count() == 0)
            {
                Console.WriteLine($"Pas de transaction pour le numero de compte {numCompte} entre {before:d(fr-Fr)} et {after:d(fr-Fr)}");
            } else
            {
                CompteBancaire compte = await compteBancaireService.GetCompteByNumForXml(transList.First().CompteBancaireNumeroCompte);
                Client client = compte.Client;
                Rapport rapport = new Rapport
                {
                    Client = client,
                    Debut = before,
                    Fin = after,
                    CompteBancaire = compte,
                    Transactions = transList.ToList<TransactionBancaire>()
                };
                var serializer = new XmlSerializer(typeof(Rapport), new Type[] {typeof(ClientParticulier), typeof(ClientProfessionnel)});

                using (var writer = new StringWriter())
                {
                    serializer.Serialize(writer, rapport);
                    string xml = writer.ToString();
                    Console.WriteLine(xml);
                    Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), @$"Rapport_client_{client.Id}_{before:dd-MM-yyyy}_{after:dd-MM-yyyy}.xml"));
                    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), @$"../../../Rapport_client_{client.Id}_{before:dd-MM-yyyy}_{after:dd-MM-yyyy}.xml"), xml);
                }
            }
        }
    }
}
