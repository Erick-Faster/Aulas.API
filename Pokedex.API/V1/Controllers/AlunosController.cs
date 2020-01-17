using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services;
using Pokedex.API.Resources;
using Pokedex.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Pokedex.API.Domain.Repositories;

namespace Pokedex.API.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class AlunosController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly IMapper _mapper;

        //Atributos para identificar o Usuario e poder interagir com eles -- opcional --
        public readonly IUser AppUser;
        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        public AlunosController(IAlunoService alunoService, IMapper mapper, IUser appUser)
        {
            _alunoService = alunoService;
            _mapper = mapper;
            AppUser = appUser;

            if (AppUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<AlunoResource>> GetAllAsync()
        {
            var alunos = await _alunoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoResource>>(alunos);

            return resources;
        }

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var result = await _alunoService.GetById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var alunoResource = _mapper.Map<Aluno, AlunoResource>(result.Aluno);
            return Ok(alunoResource);
        }
        
        [AllowAnonymous]
        //[ClaimsAuthorize("Aluno", "PostAsync")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAlunoResource resource)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
            }

            if (UsuarioAutenticado)
            {
                var userName = UsuarioId; //Se eu precisar das infos do usuario (como Id), posso usar essa implementacao
            }



            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var aluno = _mapper.Map<SaveAlunoResource, Aluno>(resource);
            var result = await _alunoService.SaveAsync(aluno);

            if (!result.Success)
                return BadRequest(result.Message);

            var alunoResource = _mapper.Map<Aluno, AlunoResource>(result.Aluno);
            return Ok(alunoResource);
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Aluno", "PutAsync")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveAlunoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var aluno = _mapper.Map<SaveAlunoResource, Aluno>(resource);
            var result = await _alunoService.UpdateAsync(id, aluno);

            if (!result.Success)
                return BadRequest(result.Message);

            var alunoResource = _mapper.Map<Aluno, AlunoResource>(result.Aluno);
            return Ok(alunoResource);
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Aluno", "DeleteAsync")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _alunoService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var alunoResource = _mapper.Map<Aluno, AlunoResource>(result.Aluno);
            return Ok(alunoResource);
        }

        

    }
}
