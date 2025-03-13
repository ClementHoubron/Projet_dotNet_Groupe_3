using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Projet.AppClient.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Projet.AppClient.Data.Repositories;
using AutoMapper;

namespace Projet.AppClient.Service
{
    public class TransactionBancaireService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionBancaireService()
        {
            _transactionRepository = new TransactionRepository();
            _mapper = MappingConfig.Mapper;
        }

        public async Task<List<TransactionBancaireDto>> GetAllTransactions()
        {
            var transactionEntities = await _transactionRepository.GetAll();
            var transactionDtos = transactionEntities.Select(trans => _mapper.Map<TransactionBancaireDto>(trans)).ToList<TransactionBancaireDto>();
            return transactionDtos;
        }
        public async Task<List<TransactionBancaireDto>> GetAllTransactionsByNumCarte(string numCarte)
        {
            var transactionEntities = await _transactionRepository.GetAllByNumCarte(numCarte);
            var transactionDtos = transactionEntities.Select(trans => _mapper.Map<TransactionBancaireDto>(trans)).ToList<TransactionBancaireDto>();
            return transactionDtos;
        }
        public async Task<List<TransactionBancaireDto>> GetAllTransactionsByNumCompte(string numCompte)
        {
            var transactionEntities = await _transactionRepository.GetAllByNumCompte(numCompte);
            var transactionDtos = transactionEntities.Select(trans => _mapper.Map<TransactionBancaireDto>(trans)).ToList<TransactionBancaireDto>();
            return transactionDtos;
        }
        public async Task<List<TransactionBancaire>> GetAllTransactionsByNumCompteForPeriod(string numCompte, DateTime before, DateTime after)
        {
            var transactionEntities = await _transactionRepository.GetAllByNumCompteForPeriod(numCompte, before, after);
            var transactions = transactionEntities.Select(trans => _mapper.Map<TransactionBancaire>(trans)).ToList<TransactionBancaire>();
            return transactions;
        }

        public async Task GenererFichierTransactions()
        {
            var transactionsValides = await _transactionRepository.GetAll();

            string json = JsonConvert.SerializeObject(transactionsValides, Formatting.Indented);
            await File.WriteAllTextAsync("transactions_validees.json", json);
        }

        public async Task<int> ImportTransactions(List<TransactionImportDto> transactions)
        {
            var transToimportEntities = transactions.Select(trans => _mapper.Map<TransactionBancaire>(trans)).ToList();
            return await _transactionRepository.ImportAll(transToimportEntities);
        }
    }
}