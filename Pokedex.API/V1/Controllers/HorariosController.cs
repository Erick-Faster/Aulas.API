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
    public class HorariosController : Controller
    {
        private readonly IHorarioService _horarioService;
        private readonly IMapper _mapper;

        public HorariosController(IHorarioService horarioService, IMapper mapper)
        {
            _horarioService = horarioService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<HorarioResource>> ListAsync()
        {
            var horarios = await _horarioService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Horario>, IEnumerable<HorarioResource>> (horarios);
            return resources;
        }

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _horarioService.GetById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var horarioResource = _mapper.Map<Horario, HorarioResource>(result.Horario);
            return Ok(horarioResource);
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Horario","PostAsync")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveHorarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var horario = _mapper.Map<SaveHorarioResource, Horario>(resource);
            var result = await _horarioService.SaveAsync(horario);

            if (!result.Success)
                return BadRequest(result.Message);

            var horarioResource = _mapper.Map<Horario, HorarioResource>(result.Horario);
            return Ok(horarioResource);
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Horario","PutAsync")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody]SaveHorarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var horario = _mapper.Map<SaveHorarioResource, Horario>(resource);
            var result = await _horarioService.UpdateAsync(id, horario);

            if (!result.Success)
                return BadRequest(result.Message);

            var horarioResource = _mapper.Map<Horario, HorarioResource>(result.Horario);
            return Ok(horarioResource);
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Horario","DeleteAsync")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _horarioService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var horarioResource = _mapper.Map<Horario, HorarioResource>(result.Horario);
            return Ok(horarioResource);
        }

    }
}
