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
    public class FeatureController : Controller
    {

        private readonly CarSMARTDBContext _context;
        private readonly IMapper _mapper;

        public FeatureController(CarSMARTDBContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures() {

            var features = await _context.Features.ToListAsync();
            return _mapper.Map<List<Features>,List<FeatureResource>>(features);
        }
        
    }
}