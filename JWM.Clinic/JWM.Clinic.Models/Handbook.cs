using System;
using System.Collections.Generic;
using System.Text;

namespace JWM.Clinic.Models
{
    public class Handbook
    {

        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; }
        public long IdVeterinary { get; set; }
        public virtual Veterinary Veterinary { get; set; }
        public long IdAnimal { get; set; }
        public virtual Animal Animal { get; set; }

    }
}
