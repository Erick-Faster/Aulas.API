using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services;
using Pokedex.API.Extensions;
using Pokedex.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Controllers.V1
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class LogAulasController : Controller
    {
        private readonly ILogAulaService _logAulaService;
        private readonly IMapper _mapper;

        public LogAulasController(ILogAulaService logAulaService, IMapper mapper)
        {
            _logAulaService = logAulaService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<LogAulaResource>> GetAllAsync()
        {
            var pokedexes = await _logAulaService.ListAsync();
            var resources = _mapper.Map<IEnumerable<LogAula>, IEnumerable<LogAulaResource>> (pokedexes);
            return resources;
        }

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _logAulaService.GetById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var logAulaResource = _mapper.Map<LogAula, LogAulaResource>(result.LogAula);
            return Ok(logAulaResource);
        }

        [ClaimsAuthorize("LogAula","PostAsync")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveLogAulaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var logAula = _mapper.Map<SaveLogAulaResource, LogAula>(resource);
            var result = await _logAulaService.SaveAsync(logAula);

            if (!result.Success)
                return BadRequest(result.Message);

            var logAulaResource = _mapper.Map<LogAula, LogAulaResource>(result.LogAula);
            return Ok(logAulaResource); 
        }

        [ClaimsAuthorize("LogAula","PutAsync")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveLogAulaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var logAula = _mapper.Map<SaveLogAulaResource, LogAula>(resource);
            var result = await _logAulaService.UpdateAsync(id, logAula);

            if (!result.Success)
                return BadRequest(result.Message);

            var logAulaResource = _mapper.Map<LogAula, LogAulaResource>(result.LogAula);
            return Ok(logAulaResource);
        }

        [ClaimsAuthorize("LogAula","DeleteAsync")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _logAulaService.DeleteAsync(id);


            if (!result.Success)
                return BadRequest(result.Message);

            var logAulaResource = _mapper.Map<LogAula, LogAulaResource>(result.LogAula);
            return Ok(logAulaResource);
            
        }
            

    }
}
