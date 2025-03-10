using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projet.Data.Repositories
{
        {

            return clients;
        }
    }
}
========
    public IEnumerable<T> GetAll() => _dbSet.ToList();
    public T GetById(int id) => _dbSet.Find(id);
    public void Add(T entity) { _dbSet.Add(entity); Save(); }
    public void Update(T entity) { _dbSet.Update(entity); Save(); }
    public void Delete(int id) { var entity = _dbSet.Find(id); if (entity != null) { _dbSet.Remove(entity); Save(); } }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
        
>>>>>>>> develop:Projet.Data/Repositories/IRepository.cs
