using System.Collections.Generic;
using System.Linq;



    public class AnomalieTransactionService
    {
        private readonly IAnomalieRepository _anomalieRepository;

        public AnomalieTransactionService(IAnomalieRepository anomalieRepository)
        {
            _anomalieRepository = anomalieRepository;
        }

        public IEnumerable<AnomalieTransactionDto> GetAllAnomalies()
        {
            return _anomalieRepository.GetAllAnomalies()
                .Select(a => new AnomalieTransactionDto
                {
                    Id = a.Id,
                    NumeroCarte = a.NumeroCarte,
                    Montant = a.Montant,
                    TypeOperation = a.TypeOperation,
                    DateOperation = a.DateOperation,
                    Devise = a.Devise,
                    Motif = a.Motif
                });
        }
    }
