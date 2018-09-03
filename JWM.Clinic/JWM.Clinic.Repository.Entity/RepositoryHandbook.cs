using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using JWM.Repositories.Comum.Entity;
using JWM.Repositories.Comum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JWM.Clinic.Repository.Entity
{
    public class RepositoryHandbook : RepositoryGenericEntity<Handbook, long>, IRepositoryHandbook
    {

        public RepositoryHandbook(Contexto contexto)
            : base(contexto)
        {

        }

        public bool Exists(long id)
        {
            return _contexto.Handbooks.Any(e => e.Id == id);
        }

        public override List<Handbook> Selection()
        {
            return _contexto.Set<Handbook>().Include(a => a.Animal).Include(m => m.Veterinary).ToList();
    

        }

        public override Handbook SelectionToId(long id) {

            //return _contexto.Set<Prontuario>().Include(a => a.Animal).Include(m => m.Medico).SingleOrDefault(p => p.Id == id);
            return _contexto.Set<Handbook>().Include(a => a.Animal).Include(m => m.Veterinary).SingleOrDefault(p => p.Id == id);
        }


    }
}
