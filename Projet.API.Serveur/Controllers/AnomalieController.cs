using Microsoft.AspNetCore.Mvc;
using Projet.Data.Entities;
using Projet.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AnomalieController : ControllerBase
    {
        private readonly AnomalieTransactionService _anomalieService;

        public AnomalieController(AnomalieTransactionService anomalieService)
        {
            _anomalieService = anomalieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnomalieTransaction>>> GetAllAnomalies()
        {
            var anomalies = await _anomalieService.GetAllAnomalies();
            return Ok(anomalies);
        }

        [HttpPost]
        public IActionResult AjouterAnomalie([FromBody] AnomalieTransaction anomalie)
        {
            if (anomalie == null)
            {
                return BadRequest("Données invalides.");
            }

            _anomalieService.AjouterAnomalie(
                anomalie.NumeroCompte,
                anomalie.Montant,
                anomalie.TypeOperation,
                anomalie.DateOperation,
                anomalie.Devise,
                anomalie.Motif
            );

            return CreatedAtAction(nameof(GetAllAnomalies), new { id = anomalie.Id }, anomalie);
        }
    }

