using Projet.AppClient.Service;
using Projet.AppClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Controller
{
    public class TransactionController
    {
        private TransactionBancaireService transactionService;
        private TransactionView transactionView;

        public TransactionController(TransactionView view)
        {
            transactionView = view;
            transactionService = new TransactionBancaireService();
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

        public async void ShowTransactionsByNumCompteForPeriod(string numCompte, DateTime before, DateTime after)
        {
            var transList = await transactionService.GetAllTransactionsByNumCompteForPeriod(numCompte, before, after);
            if (transList.Count == 0)
            {
                Console.WriteLine("Aucune Transaction !");
                return;
            }

            transactionView.DisplayTransactionList(transList);
        }
    }
}
