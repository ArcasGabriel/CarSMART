using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using DotNetAngularApp.Models;

namespace DotNetAngularApp.Controllers.Resources
{

    public class VehicleResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }

        public DateTime LastUpdate { get; set; }

        public IList<int> Features { get; set; }

        [Required]
        public Contact Contact { get; set; }

        public VehicleResource()
        { 
            Features = new List<int>();
        }

    }
}