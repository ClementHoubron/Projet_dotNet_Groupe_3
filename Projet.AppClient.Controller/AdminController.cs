using Projet.AppClient.Service;
using Projet.AppClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Controller
{
    public class AdminController
    {
        private AdminService adminService;

        public AdminController()
        {
            adminService = new AdminService();
        }

        public async Task<bool> Login(string login, string mdp)
        {
            var logOk = await adminService.Login(login, mdp);
            return logOk;
        }
    }
}
