using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using JWM.Repositories.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.Repository.Entity
{
    public class AnimalRepository : RepositoryGenericEntity<Animal, long>
    {
        public AnimalRepository(Contexto contexto)
            : base(contexto)
        {

        }
    }
}
