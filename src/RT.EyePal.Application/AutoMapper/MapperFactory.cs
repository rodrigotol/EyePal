using System;
using AutoMapper;
using RT.EyePal.Application.Interfaces;
using RT.EyePal.Application.Interfaces.AutoMapper;

namespace RT.EyePal.Application.AutoMapper
{
    public class MapperFactory<TMap> where TMap : ICoreMapper, new()
    {
        public static IMapper CreateNewMapper()
        {
            return (new TMap()).CreateMapping();
        } 
    }
}