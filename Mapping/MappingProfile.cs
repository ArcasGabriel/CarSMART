using System.Linq;
using AutoMapper;
using DotNetAngularApp.Core.Models;
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
            CreateMap<Vehicle, SaveVehicleResource>()
            .ForMember(vr => vr.Contact, opt=> opt.MapFrom(v => new Contact{ Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone}))
            .ForMember(vr => vr.Features, opt=> opt.MapFrom(v => v.Features.Select(vr => vr.FeatureId)));

            CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
            .ForMember(vr => vr.Contact, opt=> opt.MapFrom(v => new Contact{ Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone}))
            .ForMember(vr => vr.Features, opt=> opt.MapFrom(v => v.Features.Select(vr => new FeatureResource { Id = vr.Feature.Id, Name = vr.Feature.Name})));

            // API Resources to Domain Models
             CreateMap<SaveVehicleResource, Vehicle>()
              .ForMember(v => v.Id, opt => opt.Ignore())
              .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
              .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
              .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
              .ForMember(v => v.Features, opt => opt.Ignore())
              .AfterMap((vr, v) => {
                // Remove unselected features
                var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                foreach (var f in removedFeatures)
                  v.Features.Remove(f);

                // Add new features
                var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id }).ToList();   
                foreach (var f in addedFeatures)
                    v.Features.Add(f);
            });
        }
    }
}