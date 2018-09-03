using JWM.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Repositories.Comum
{
    public interface IRepositoryVeterinary : IRepositoryGeneric<Veterinary, long>
    {
        bool Exists(long id);
    }
}
