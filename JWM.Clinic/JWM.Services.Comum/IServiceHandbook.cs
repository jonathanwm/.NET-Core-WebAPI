using JWM.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Services.Comum
{
    public interface IServiceHandbook : IServiceGeneric<Handbook, long>
    {
        bool Exists(long id);
    }
}
