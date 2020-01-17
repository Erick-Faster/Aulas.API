using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Repositories;
using Pokedex.API.Domain.Services;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Services
{
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HorarioService(IHorarioRepository horarioRepository, IUnitOfWork unitOfWork)
        {
            _horarioRepository = horarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Horario>> ListAsync()
        {
            return await _horarioRepository.ListAsync();
        }

        public async Task<SaveHorarioResponse> GetById(Guid id)
        {
            var existingRepository = await _horarioRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SaveHorarioResponse("Horario nao encontrado");

            return new SaveHorarioResponse(existingRepository);
        }

        public async Task<SaveHorarioResponse> SaveAsync(Horario horario)
        {
            try
            {
                await _horarioRepository.AddAsync(horario);
                await _unitOfWork.CompleteAsync();

                return new SaveHorarioResponse(horario);
            }
            catch (Exception ex)
            {
                return new SaveHorarioResponse($"Nao foi possivel salvar o Horario: {ex.Message}");
            }
        }

        public async Task<SaveHorarioResponse> UpdateAsync(Guid id, Horario horario)
        {
            var existingRepository = await _horarioRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SaveHorarioResponse("Horario nao encontrado");

            existingRepository.Intervalo = horario.Intervalo;
            existingRepository.Disponivel = horario.Disponivel;
            existingRepository.Id_Aluno = horario.Id_Aluno;
            existingRepository.Id_Pokedex = horario.Id_Pokedex;

            try
            {
                _horarioRepository.Update(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SaveHorarioResponse(existingRepository);

            }
            catch (Exception ex)
            {
                return new SaveHorarioResponse($"Um erro ocorreu ao atualizar o horario: {ex.Message}");
            }
        }

        public async Task<SaveHorarioResponse> DeleteAsync(Guid id)
        {
            var existingRepository = await _horarioRepository.FindByIdAsync(id);

            if (existingRepository == null)
            {
                return new SaveHorarioResponse("Horario nao encontrado");
            }

            try
            {
                _horarioRepository.Remove(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SaveHorarioResponse(existingRepository);
            }
            catch(Exception ex)
            {
                return new SaveHorarioResponse($"Erro ao Deletar Horario: {ex.Message}");
            }
        }

        
    }
}
