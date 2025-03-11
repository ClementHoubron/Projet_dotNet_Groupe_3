
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionBancaireService _transactionService;

        public TransactionController(TransactionBancaireService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionBancaireDto>> GetAllTransactions()
        {
            return Ok(_transactionService.GetAllTransactions());
        }

        //[HttpGet("compte/{compteId}")]
        //public ActionResult<IEnumerable<TransactionBancaireDto>> GetTransactionsByCompte(int compteId)
        //{
        //    return Ok(_transactionService.GetTransactionsByCompte(compteId));
        //}

        [HttpPost]
        public ActionResult AjouterTransaction([FromBody] TransactionBancaireDto transactionDto)
        {
            if (transactionDto == null) return BadRequest("Les données sont invalides.");

            _transactionService.AjouterTransaction(transactionDto);
            return Ok("Transaction ajoutée avec succès !");
        }

        [HttpGet("export-json")]
        public IActionResult ExportTransactions()
        {
            try
            {
                _transactionService.GenererFichierTransactions();
                return Ok("Fichier JSON des transactions généré avec succès !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur lors de l'exportation : {ex.Message}");
            }
        }
   }
