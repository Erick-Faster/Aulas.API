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
    public class AlunoService : IAlunoService
    {

        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoService(IAlunoRepository alunoRepository, IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Aluno>> ListAsync()
        {
            return await _alunoRepository.ListAsync();
        }

        public async Task<SaveAlunoResponse> GetById(Guid id)
        {
            var existingAluno = await _alunoRepository.FindByIdAsync(id);

            if (existingAluno == null)
                return new SaveAlunoResponse("Treinador nao encontrado");

            return new SaveAlunoResponse(existingAluno);
        }

        public async Task<SaveAlunoResponse> SaveAsync(Aluno aluno)
        {
            try
            {
                await _alunoRepository.AddAsync(aluno);
                await _unitOfWork.CompleteAsync();

                return new SaveAlunoResponse(aluno);
            }
            catch (Exception ex)
            {
                return new SaveAlunoResponse($"Erro ao salvar: {ex.Message}");
            }
        }

        public async Task<SaveAlunoResponse> UpdateAsync(Guid id, Aluno aluno)
        {
            var existingAluno = await _alunoRepository.FindByIdAsync(id);

            if(existingAluno == null)
            {
                return new SaveAlunoResponse("Treinador nao encontrado");
                
            }
            existingAluno.Nome = aluno.Nome;
            existingAluno.Email = aluno.Email;
            existingAluno.Nivel = aluno.Nivel;
            existingAluno.Idioma = aluno.Idioma;

            try
            {
                _alunoRepository.Update(existingAluno);
                await _unitOfWork.CompleteAsync();

                return new SaveAlunoResponse(existingAluno);
            }
            catch(Exception ex)
            {
                return new SaveAlunoResponse($"Erro ao atualizar treinador: {ex.Message}");
            }
        }

        public async Task<SaveAlunoResponse> DeleteAsync(Guid id)
        {
            var existingAluno = await _alunoRepository.FindByIdAsync(id);

            if (existingAluno == null)
                return new SaveAlunoResponse("Treinador nao encontrado");

            try
            {
                _alunoRepository.Remove(existingAluno);
                await _unitOfWork.CompleteAsync();

                return new SaveAlunoResponse(existingAluno);
            }
            catch (Exception ex)
            {
                return new SaveAlunoResponse($"Erro ao deletar o arquivo: {ex.Message}");
            }
        }

        
    }
}
