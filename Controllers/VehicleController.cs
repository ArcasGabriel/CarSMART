using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetAngularApp.Controllers.Resources;
using DotNetAngularApp.Models;
using DotNetAngularApp.Persistence;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(veh => veh.Id == id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<VehicleResource,Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);


            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();
            context.Remove(vehicle);

            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(vehicle => vehicle.Id == id);
            
            if (vehicle == null)
                return NotFound();
            
            var vehicleResource = mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(vehicleResource);
            
        }
        
    }
}