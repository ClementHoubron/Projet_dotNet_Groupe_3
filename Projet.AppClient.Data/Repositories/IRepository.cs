using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();

    }
}