using AutoMapper;
using DotNetAngularApp.Models;
using DotNetAngularApp.Controllers.Resources;

namespace DotNetAngularApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Features, FeatureResource>();
        }
    }
}