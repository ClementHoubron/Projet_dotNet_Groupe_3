using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


    [Route("api/anomalies")]
    [ApiController]
    public class AnomalieController : ControllerBase
    {
        private readonly AnomalieTransactionService _anomalieService;

        public AnomalieController(AnomalieTransactionService anomalieService)
        {
            _anomalieService = anomalieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnomalieTransactionDto>> GetAllAnomalies()
        {
            return Ok(_anomalieService.GetAllAnomalies());
        }
    }

