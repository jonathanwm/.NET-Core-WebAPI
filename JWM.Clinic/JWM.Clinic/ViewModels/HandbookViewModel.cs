using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWM.Clinic.API.ViewModels
{
    public class HandbookViewModel
    {

        public long Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual string Hour { get; set; }
        public string Observation { get; set; }
        public long IdVeterinary { get; set; }
        public long IdAnimal { get; set; }
        
    }
}
