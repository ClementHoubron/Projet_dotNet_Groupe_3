using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


    [Route("api/anomalies")]
    [ApiController]
    public class AnomalieController : ControllerBase
    {
        private readonly IAnomalieRepository _anomalieRepository;

        public AnomalieController(IAnomalieRepository anomalieRepository)
        {
            _anomalieRepository = anomalieRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnomalieTransactionDto>> GetAllAnomalies()
        {
            var anomalies = _anomalieRepository.GetAll()
                .Select(a => new AnomalieTransactionDto
                {
                    Id = a.Id,
                    NumeroCarte = a.NumeroCarte,
                    Montant = a.Montant,
                    TypeOperation = a.TypeOperation,
                    DateOperation = a.DateOperation,
                    Devise = a.Devise,
                    Motif = a.Motif
                })
                .ToList();

            return Ok(anomalies);
        }
    }

