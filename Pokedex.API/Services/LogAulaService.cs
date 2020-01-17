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
    public class LogAulaService : ILogAulaService
    {
        private readonly ILogAulaRepository _logAulaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LogAulaService(ILogAulaRepository logAulaRepository, IUnitOfWork unitOfWork)
        {
            _logAulaRepository = logAulaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LogAula>> ListAsync()
        {
            return await _logAulaRepository.ListAsync();
        }

        public async Task<SaveLogAulaResponse> GetById(Guid id)
        {
            var existingRepository = await _logAulaRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SaveLogAulaResponse("Informação não encontrada");

            return new SaveLogAulaResponse(existingRepository);
        }

        public async Task<SaveLogAulaResponse> SaveAsync(LogAula logAula)
        {
            try
            {
                await _logAulaRepository.AddAsync(logAula);
                await _unitOfWork.CompleteAsync();

                return new SaveLogAulaResponse(logAula);
            }
            catch(Exception ex)
            {
                return new SaveLogAulaResponse($"Erro ao salvar pokedex: {ex.Message}");
            }
        }

        public async Task<SaveLogAulaResponse> UpdateAsync(Guid id, LogAula logAula)
        {
            var existingRepository = await _logAulaRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SaveLogAulaResponse("Informacao nao encontrada");

            existingRepository.Sucesso = logAula.Sucesso;
            existingRepository.Observacoes = logAula.Observacoes;

            try
            {
                _logAulaRepository.Update(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SaveLogAulaResponse(existingRepository);
            }
            catch(Exception ex)
            {
                return new SaveLogAulaResponse($"Erro ao Atualizar: {ex.Message}");
            }

        }

        public async Task<SaveLogAulaResponse> DeleteAsync(Guid id)
        {
            var existingRepository = await _logAulaRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SaveLogAulaResponse("Informacao nao encontrada");

            try
            {
                _logAulaRepository.Remove(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SaveLogAulaResponse(existingRepository);
            }
            catch(Exception ex)
            {
                return new SaveLogAulaResponse($"Erro ao Deletar: {ex.Message}");
            }

        }

        
    }
}
