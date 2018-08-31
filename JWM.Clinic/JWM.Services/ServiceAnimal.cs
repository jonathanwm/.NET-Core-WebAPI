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

        private readonly IRepositoryGeneric<Animal, long> _repositoriesAnimals;

        public ServiceAnimal(IRepositoryGeneric<Animal, long> repositoriesAnimals)
            : base(repositoriesAnimals)
        {
            _repositoriesAnimals = repositoriesAnimals;

        }
    }
}
