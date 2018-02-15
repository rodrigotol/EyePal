using System.Drawing;
using AutoMapper;
using RT.EyePal.Application.Interfaces;
using RT.EyePal.Application.Interfaces.AutoMapper;
using RT.EyePal.Application.ViewModels;
using RT.EyePal.Domain.Entities;

namespace RT.EyePal.Application.AutoMapper
{
    public class MainWindowMapperProfile : ICoreMapper
    {
        public IMapper CreateMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FilterConfigurationViewModel, FilterConfiguration>()
                    .ForMember(dest => dest.FilterOpacity,
                        opt => opt.MapFrom(src => src.FilterOpacity))
                    .ForMember(dest => dest.FilterColorA, 
                        opt=> opt.MapFrom(src=>src.FilterColor.A))
                    .ForMember(dest => dest.FilterColorR,
                        opt => opt.MapFrom(src => src.FilterColor.R))
                    .ForMember(dest => dest.FilterColorG,
                        opt => opt.MapFrom(src => src.FilterColor.G))
                    .ForMember(dest => dest.FilterColorB,
                        opt => opt.MapFrom(src => src.FilterColor.B));

                cfg.CreateMap<FilterConfiguration, FilterConfigurationViewModel>()
                    .ForMember(dest => dest.FilterOpacity,
                        opt => opt.MapFrom(src => src.FilterOpacity))
                    .ForMember(dest => dest.FilterColor,
                        opt => opt.MapFrom(src => src.CreateNewFilterColor()));
            });

            return config.CreateMapper();
        }
    
    }
}