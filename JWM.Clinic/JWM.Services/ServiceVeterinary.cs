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

        private readonly IRepositoryVeterinary _repositoryVeterinaries;

        public ServiceVeterinary(IRepositoryVeterinary repositoryVeterinaries)
            : base(repositoryVeterinaries)
        {
            _repositoryVeterinaries = repositoryVeterinaries;
        }

        public bool Exists(long id)
        {
            return _repositoryVeterinaries.Exists(id);
        }
    }
}
