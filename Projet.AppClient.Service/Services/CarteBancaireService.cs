using AutoMapper;
using Projet.AppClient.Data.Entities;
using Projet.AppClient.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Service.Services
{
    public class CarteBancaireService
    {
        private readonly CarteBancaireRepository _repo;
        private readonly IMapper _mapper;
        public CarteBancaireService()
        {
            _repo = new CarteBancaireRepository();
            _mapper = MappingConfig.Mapper;
        }

        public async void AddCarte(CarteBancaireDto carteDto)
        {
            var carteEntity = _mapper.Map<CarteBancaire>(carteDto);
            _repo.Add(carteEntity);
        }

        public async Task<CarteBancaireDto> GetCarteByNumCarte(string numCarte)
        {
            var carteEntity = await _repo.GetByNumCarte(numCarte);
            var carteDto = _mapper.Map<CarteBancaireDto>(carteEntity);

            return carteDto;
        }

        public async Task<List<CarteBancaireDto>> GetCartesByNumCompte(string numCompte)
        {
            var cartesEntities = await _repo.GetAllByNumCompte(numCompte);
            var cartesDto = cartesEntities.Select(carte => _mapper.Map<CarteBancaireDto>(carte)).ToList<CarteBancaireDto>();
            return cartesDto;
        }

        public async Task<List<CarteBancaireDto>> GetCartes()
        {
            var cartesEntities = await _repo.GetAll();
            var cartesDto = cartesEntities.Select(carte => _mapper.Map<CarteBancaireDto>(carte)).ToList<CarteBancaireDto>();
            return cartesDto;
        }
    }
}
