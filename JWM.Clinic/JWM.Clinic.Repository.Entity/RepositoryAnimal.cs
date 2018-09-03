using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using JWM.Repositories.Comum;
using JWM.Repositories.Comum.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.Repository.Entity
{
    public class RepositoryAnimal : RepositoryGenericEntity<Animal, long>, IRepositoryAnimal
    {
        public RepositoryAnimal(Contexto contexto)
            : base(contexto)
        {


        }

        public bool Exists(long id)
        {
            return _contexto.Animals.Any(e => e.Id == id);
        }

        
    }
}
