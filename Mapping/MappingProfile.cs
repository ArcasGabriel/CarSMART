using System.Linq;
using AutoMapper;
using DotNetAngularApp.Models;
using DotNetAngularApp.Controllers.Resources;

namespace DotNetAngularApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain Model to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Features, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Contact, opt=> opt.MapFrom(v => new Contact{ Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone}))
            .ForMember(vr => vr.Features, opt=> opt.MapFrom(v => v.Features.Select(vr => vr.FeatureId)));

            // API Resources to Domain Models
            CreateMap<VehicleResource,Vehicle>()
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactPhone, opt=> opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.ContactEmail, opt=> opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature {FeatureId = id})))
                ;
        }
    }
}