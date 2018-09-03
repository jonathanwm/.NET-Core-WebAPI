using JWM.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Repositories.Comum
{
    public interface IRepositoryAnimal : IRepositoryGeneric<Animal, long>
    {
        bool Exists(long id);
    }
}
