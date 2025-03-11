using Microsoft.AspNetCore.Mvc;
using Projet.AppClient.Service.Services;


    [ApiController]
    [Route("api/[controller]")]
    public class CompteBancaireController : Controller
    {
        private readonly CompteBancaireService compteService;

        public CompteBancaireController()
        {
            this.compteService = new CompteBancaireService();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompteBancaireDto>>> GetComptes()
        {
            return await compteService.GetComptes();
        }

        [HttpGet("{numCompte}")]
        public async Task<ActionResult<CompteBancaireDto>> GetCompteByNumCompte(string numCompte)
        {
            var compteDto = await compteService.GetCompteByNum(numCompte);

            if (compteDto == null)
            {
                return NotFound();
            }
            return Ok(compteDto);
        }
    }
