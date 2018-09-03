using JWM.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Services.Comum
{
    public interface IServiceAnimal : IServiceGeneric<Animal, long>
    {

        bool Exists(long id);

    }
}
