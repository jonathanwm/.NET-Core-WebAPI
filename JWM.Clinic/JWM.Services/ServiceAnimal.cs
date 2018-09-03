using JWM.Clinic.Models;
using JWM.Repositories.Comum;
using JWM.Services.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Services
{
    public class ServiceAnimal : ServiceBase<Animal, long>, IServiceAnimal
    {

        private readonly IRepositoryAnimal _repositoryAnimals;

        public ServiceAnimal(IRepositoryAnimal repositoryAnimals)
            : base(repositoryAnimals)
        {
            _repositoryAnimals = repositoryAnimals;

        }

        public bool Exists(long id)
        {
            return _repositoryAnimals.Exists(id);
        }
    }
}
