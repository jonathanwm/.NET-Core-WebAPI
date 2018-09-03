using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWM.Clinic.API.ViewModels
{
    public class HandbookExibicaoViewModel
    {

        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public string Observation { get; set; }
        public string NameVeterinary { get; set; }
        public string NameAnimal { get; set; }
        
    }
}
