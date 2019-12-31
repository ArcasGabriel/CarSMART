using System;
using System.Collections.Generic;

namespace DotNetAngularApp.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ModelResource Model { get; set; }
        public MakeResource Make { get; set; }
        public bool IsRegistered { get; set; }

        public Contact Contact { get; set; }
        public DateTime LastUpdate { get; set; }

        public IList<FeatureResource> Features { get; set; }



        public VehicleResource()
        {
          Features = new List<FeatureResource>();   
        }
    }
}