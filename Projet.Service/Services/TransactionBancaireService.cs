
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;



    public class TransactionBancaireService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionBancaireService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<TransactionBancaireDto> GetAllTransactions()
        {
            return _transactionRepository.GetAll().Select(t => new TransactionBancaireDto
            {
                Id = t.Id,
                NumeroCarte = t.NumeroCarte,
                Montant = t.Montant,
                TypeOperation = t.TypeOperation,
                DateOperation = t.DateOperation,
                Devise = t.Devise,
                CompteBancaireId = t.CompteBancaireId,
                EstValide = t.EstValide
            });
        }

        public IEnumerable<TransactionBancaireDto> GetTransactionsByCompte(int compteId)
        {
            return _transactionRepository.GetTransactionsByAccountId(compteId)
                .Select(t => new TransactionBancaireDto
                {
                    Id = t.Id,
                    NumeroCarte = t.NumeroCarte,
                    Montant = t.Montant,
                    TypeOperation = t.TypeOperation,
                    DateOperation = t.DateOperation,
                    Devise = t.Devise,
                    CompteBancaireId = t.CompteBancaireId,
                    EstValide = t.EstValide
                });
        }

        public void AjouterTransaction(TransactionBancaireDto transactionDto)
        {
            var transaction = new TransactionBancaire
            {
                NumeroCarte = transactionDto.NumeroCarte,
                Montant = transactionDto.Montant,
                TypeOperation = transactionDto.TypeOperation,
                DateOperation = transactionDto.DateOperation,
                Devise = transactionDto.Devise,
                CompteBancaireId = transactionDto.CompteBancaireId,
                EstValide = true
            };

            _transactionRepository.AjouterTransactionAvecVerification(transaction);
        }

        public void GenererFichierTransactions()
        {
            var transactionsValides = _transactionRepository.GetAll().Where(t => t.EstValide).ToList();
            string json = JsonConvert.SerializeObject(transactionsValides, Formatting.Indented);
            File.WriteAllText("transactions_validees.json", json);
        }
    }

