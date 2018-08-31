using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.Models;
using JWM.Repositories.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.Repository.Entity
{
    public class VeterinaryRepository : RepositoryGenericEntity<Veterinary, long>
    {
        public VeterinaryRepository(Contexto contexto)
            : base(contexto)
        {

        }

    }
}
