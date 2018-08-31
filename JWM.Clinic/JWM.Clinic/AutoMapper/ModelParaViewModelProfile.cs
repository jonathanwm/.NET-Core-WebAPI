using AutoMapper;
using JWM.Clinic.API.ViewModels;
using JWM.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWM.Clinic.API.AutoMapper
{
    public class ModelParaViewModelProfile : Profile
    {


        public ModelParaViewModelProfile()
        {
            CreateMap<Handbook, HandbookExibicaoViewModel>()
                .ForMember(p => p.NameAnimal, opt =>
                            opt.MapFrom(src => src.Animal.Name)
                           )
                .ForMember(p => p.NameVeterinary, opt =>
                            opt.MapFrom(src => src.Veterinary.Name)
                            )
                .ForMember(p => p.Hour, opt =>
                            opt.MapFrom(src => src.Date.ToShortTimeString())
                            );

            CreateMap<Handbook, HandbookViewModel>()
                .ForMember(p => p.Hour, opt =>
                            opt.MapFrom(src => src.Date.ToLongTimeString())
                );

        }
        

    }
}
