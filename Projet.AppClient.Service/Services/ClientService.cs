using AutoMapper;
using Projet.AppClient.Data.Entities;
using Projet.AppClient.Data.Repositories;
using Projet.AppClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Service
{
    public class ClientService
    {
        private readonly ClientRepository _repo;
        private readonly IMapper _mapper;
        public ClientService()
        {
            _repo = new ClientRepository();
            _mapper = MappingConfig.Mapper;
        }


        public async Task<List<ClientDto>> GetClients()
        {
            var prodEntities = await _repo.GetAll();

            var clientsDto = prodEntities.Select(cli =>
            {
                if (cli is ClientParticulier)
                {
                    return _mapper.Map<ClientParticulierDto>(cli);
                }
                else if (cli is ClientProfessionnel)
                {
                    return _mapper.Map<ClientProfessionnelDto>(cli);
                }
                else
                    return _mapper.Map<ClientDto>(cli);
            }).ToList<ClientDto>();

            return clientsDto;
        }

        public async Task<int> AddClientParticulier(ClientParticulierDto cliDto)
        {
            var cliEntity = _mapper.Map<ClientParticulier>(cliDto);
            var cliSaved = await _repo.AddClientParticulier(cliEntity);
            return cliSaved;
        }

        public async Task<int> AddClientProfessionnel(ClientProfessionnelDto cliDto)
        {
            var cliEntity = _mapper.Map<ClientProfessionnel>(cliDto);
            var cliSaved = await _repo.AddClientProfessionnel(cliEntity);
            return cliSaved;
        }

        public async Task<ClientParticulierDto> GetByNomPrenom(string nom, string prenom)
        {
            var cliEntity = await _repo.GetByNomPrenom(nom, prenom);
            var cliDto = _mapper.Map<ClientParticulierDto>(cliEntity);
            return cliDto;
        }

        public async Task<ClientProfessionnelDto> GetByNomSiret(string nom, string siret)
        {
            var cliEntity = await _repo.GetByNomSiret(nom, siret);
            var cliDto = _mapper.Map<ClientProfessionnelDto>(cliEntity);
            return cliDto;
        }
    }
}
