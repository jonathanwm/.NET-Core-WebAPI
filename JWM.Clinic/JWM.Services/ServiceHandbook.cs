using JWM.Clinic.Models;
using JWM.Repositories.Comum;
using JWM.Services.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Services
{
    public class ServiceHandbook : ServiceBase<Handbook, long>, IServiceHandbook
    {

        private readonly IRepositoryGeneric<Handbook, long> _repositoriesHandbooks;

        public ServiceHandbook(IRepositoryGeneric<Handbook, long> repositoriesHandbooks)
            : base(repositoriesHandbooks)
        {
            _repositoriesHandbooks = repositoriesHandbooks;
        }
    }
}
