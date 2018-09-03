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

        private readonly IRepositoryHandbook _repositoryHandbooks;

        public ServiceHandbook(IRepositoryHandbook repositoryHandbooks)
            : base(repositoryHandbooks)
        {
            _repositoryHandbooks = repositoryHandbooks;
        }

        public bool Exists(long id)
        {
            return _repositoryHandbooks.Exists(id);
        }
    }
}
