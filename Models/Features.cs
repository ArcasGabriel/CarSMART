using DotNetAngularApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetAngularApp.Models
{
    public class Features
    {
        public int Id { get; set; } 


        [Required]
        [StringLength(255)]
        public string Name { get; set; }   

         public IList<VehicleFeature> Vehicles { get; set; }

        public Features()
        {
          Vehicles = new List<VehicleFeature>();   
        }
    }
}