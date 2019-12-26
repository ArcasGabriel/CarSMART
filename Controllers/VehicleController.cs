using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetAngularApp.Controllers.Resources;
using DotNetAngularApp.Models;
using DotNetAngularApp.Persistence;
using System.Threading.Tasks;

namespace DotNetAngularApp.Controllers
{
     [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IMapper mapper;
        private readonly CarSMARTDBContext context;
        public VehicleController(IMapper mapper, CarSMARTDBContext context)
        {
            this.mapper = mapper;   
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            
            var vehicle = mapper.Map<VehicleResource,Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);


            return Ok(result);
        }
        
    }
}