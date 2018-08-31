using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using JWM.Repositories.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JWM.Clinic.Repository.Entity
{
    public class HandbookRepository : RepositoryGenericEntity<Handbook, long>
    {

        public HandbookRepository(Contexto contexto)
            : base(contexto)
        {

        }

        public override List<Handbook> Selection()
        {
            return _contexto.Set<Handbook>().Include(a => a.Animal).Include(m => m.Veterinary).ToList();
    

        }

    
    }
}
