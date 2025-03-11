using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Projet.AppClient.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Repositories;

namespace Projet.AppClient.Service
{
    public class TransactionBancaireService
    {
        private readonly TransactionRepository _transactionRepository;

        public TransactionBancaireService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionBancaireDto>> GetAllTransactions()
        {
            var transactions = await _transactionRepository.GetAll();
            return transactions.Select(t => new TransactionBancaireDto
            {
                Id = t.Id,
                //NumeroCarte = t.NumeroCarte,
                Montant = t.Montant,
                TypeOperation = t.TypeOperation,
                DateOperation = t.DateOperation,
                Devise = t.Devise,
                EstValide = t.EstValide
            });
        }

        public async Task AjouterTransaction(TransactionBancaireDto transactionDto)
        {
            var transaction = new TransactionBancaire
            {
               // NumeroCarte = transactionDto.NumeroCarte,
                Montant = transactionDto.Montant,
                TypeOperation = transactionDto.TypeOperation,
                DateOperation = transactionDto.DateOperation,
                Devise = transactionDto.Devise,
                EstValide = true
            };

            if (!ValiderNumeroCarte(transaction.NumeroCarte))
            {
                Console.WriteLine("TODO");
            }
            else
            {
                _transactionRepository.AjouterTransactionAvecVerification(transaction);
            }
        }

        public async Task GenererFichierTransactions()
        {
            var transactionsValides = await _transactionRepository.GetAll();
            var transactionsFiltrees = transactionsValides.Where(t => t.EstValide).ToList();

            string json = JsonConvert.SerializeObject(transactionsFiltrees, Formatting.Indented);
            await File.WriteAllTextAsync("transactions_validees.json", json);
        }

        private bool ValiderNumeroCarte(string numeroCarte)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = numeroCarte.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(numeroCarte[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
    }
}