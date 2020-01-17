using AutoMapper;
using Pokedex.API.Domain.Models;
using Pokedex.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAlunoResource, Aluno>();
            CreateMap<SaveEnderecoResource, Endereco>();
            CreateMap<SaveLogAulaResource, LogAula>();
            CreateMap<SaveHorarioResource, Horario>();
        }
    }
}
