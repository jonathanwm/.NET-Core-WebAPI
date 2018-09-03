using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using JWM.Repositories.Comum;
using JWM.Repositories.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWM.Clinic.Repository.Entity
{
    public class RepositoryVeterinary : RepositoryGenericEntity<Veterinary, long>, IRepositoryVeterinary
    {
        public RepositoryVeterinary(Contexto contexto)
            : base(contexto)
        {

        }

        public bool Exists(long id)
        {
            return _contexto.Veterinaries.Any(e => e.Id == id);
        }
    }
}
