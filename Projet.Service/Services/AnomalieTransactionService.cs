using Projet.Data.Entities;
using Projet.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projet.Services
{
    public class AnomalieTransactionService
    {
        private readonly AnomalieRepository _anomalieRepository;

        public AnomalieTransactionService(AnomalieRepository anomalieRepository)
        {
            _anomalieRepository = anomalieRepository;
        }

        public async Task<List<AnomalieTransaction>> GetAllAnomalies()
        {
            return await _anomalieRepository.GetAll();
        }

        public void AjouterAnomalie(string numeroCarte, decimal montant, string typeOperation,
                                    DateTime dateOperation, string devise, string motif)
        {
            var anomalie = new AnomalieTransaction
            {
                NumeroCarte = numeroCarte,
                Montant = montant,
                TypeOperation = typeOperation,
                DateOperation = dateOperation,
                Devise = devise,
                Motif = motif
            };

            _anomalieRepository.AjouterAnomalie(anomalie);
        }
    }
}
