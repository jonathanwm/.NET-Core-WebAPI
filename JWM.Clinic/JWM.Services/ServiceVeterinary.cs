using JWM.Clinic.Models;
using JWM.Repositories.Comum;
using JWM.Services.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Services
{
    public class ServiceVeterinary : ServiceBase<Veterinary, long>, IServiceVeterinary
    {

        private readonly IRepositoryGeneric<Veterinary, long> _repositoriesVeterinaries;

        public ServiceVeterinary(IRepositoryGeneric<Veterinary, long> repositoriesVeterinaries)
            : base(repositoriesVeterinaries)
        {
            _repositoriesVeterinaries = repositoriesVeterinaries;
        }
    }
}
