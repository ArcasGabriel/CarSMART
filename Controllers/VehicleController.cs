using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DotNetAngularApp.Controllers.Resources;
using DotNetAngularApp.Core.Models;
using DotNetAngularApp.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotNetAngularApp.Controllers
{
     [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public VehicleController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            
            var vehicle = mapper.Map<SaveVehicleResource,Vehicle>(vehicleResource);

            vehicle.LastUpdate = DateTime.Now;
            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);


            return Ok(result);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource,Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);


            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeRelated : false);

            if (vehicle == null)
                return NotFound();
            repository.Remove(vehicle);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var vehicle = await repository.GetVehicle(id);
            
            if (vehicle == null)
                return NotFound();
            
            var vehicleResource = mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(vehicleResource);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var vehicles = await repository.GetVehicles();

                if (vehicles == null)
                    return NotFound();

                var vehicleResource = mapper.Map<IList<Vehicle>,IList<VehicleResource>>(vehicles);

                return Ok(vehicleResource);
            }
        
        
    }
}