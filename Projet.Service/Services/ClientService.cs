﻿using AutoMapper;
using Projet.Data.Entities;
using Projet.Data.Repositories;
using Projet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Business.Services
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


    }
}
