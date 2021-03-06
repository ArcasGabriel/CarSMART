using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace DotNetAngularApp.Core.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        public DateTime LastUpdate { get; set; }

        public IList<VehicleFeature> Features { get; set; }

        public Vehicle()
        {
          Features = new List<VehicleFeature>();   
        }
    }
}