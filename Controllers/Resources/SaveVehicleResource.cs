using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace DotNetAngularApp.Controllers.Resources
{

    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }

        public IList<int> Features { get; set; }

        [Required]
        public Contact Contact { get; set; }

        public SaveVehicleResource()
        { 
            Features = new List<int>();
        }

    }
}