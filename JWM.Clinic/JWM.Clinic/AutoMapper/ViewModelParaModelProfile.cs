using AutoMapper;
using JWM.Clinic.API.ViewModels;
using JWM.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWM.Clinic.API.AutoMapper
{
    public class ViewModelParaModelProfile : Profile
    {

        public ViewModelParaModelProfile()
        {
            CreateMap<HandbookViewModel, Handbook>();
            
        }
    }
}
