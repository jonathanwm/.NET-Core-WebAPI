using JWM.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Repositories.Comum
{
    public interface IRepositoryHandbook : IRepositoryGeneric<Handbook, long>
    {
        bool Exists(long id);
    }
}
