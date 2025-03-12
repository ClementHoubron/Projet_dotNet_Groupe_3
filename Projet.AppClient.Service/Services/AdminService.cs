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
    public class AdminService
    {
        private readonly AdminRepository _repo;
        private readonly IMapper _mapper;
        public AdminService()
        {
            _repo = new AdminRepository();
            _mapper = MappingConfig.Mapper;
        }


        public async Task<bool> Login(string login, string mdp)
        {
            return await _repo.Login(login, mdp);
        }


    }
}
