using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DotNetAngularApp.Core.Models;
using DotNetAngularApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using DotNetAngularApp.Controllers.Resources;


namespace DotNetAngularApp.Controllers
{
    public class MakesController: Controller
    {
        private readonly CarSMARTDBContext context;
        private readonly IMapper _mapper;
        public MakesController(CarSMARTDBContext context, IMapper _mapper)
        {
            this.context = context;   
            this._mapper = _mapper;
        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes() {


            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return _mapper.Map<List<Make>, List<MakeResource>>(makes);

        }
        
    }
}