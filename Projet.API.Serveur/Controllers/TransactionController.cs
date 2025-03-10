
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionBancaireDto>> GetAllTransactions()
        {
            var transactions = _transactionRepository.GetAll()
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
                })
                .ToList();

            return Ok(transactions);
        }

        [HttpGet("compte/{compteId}")]
        public ActionResult<IEnumerable<TransactionBancaireDto>> GetTransactionsByCompte(int compteId)
        {
            var transactions = _transactionRepository.GetTransactionsByAccountId(compteId);
            return Ok(transactions);
        }

        [HttpPost]
        public ActionResult AjouterTransaction([FromBody] TransactionBancaireDto transactionDto)
        {
            if (transactionDto == null) return BadRequest("Les données sont invalides.");

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
            return Ok("Transaction ajoutée avec succès !");
        }

        [HttpGet("export-json")]
        public IActionResult ExportTransactions()
        {
            try
            {
                _transactionRepository.GenererFichierTransactions();
                return Ok("Fichier JSON des transactions généré avec succès !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur lors de l'exportation : {ex.Message}");
            }
        }
    }
