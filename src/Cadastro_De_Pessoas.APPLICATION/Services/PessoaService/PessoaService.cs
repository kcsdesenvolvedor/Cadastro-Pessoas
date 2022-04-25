using Cadastro_De_Pessoas.APPLICATION.Models.Dtos;
using Cadastro_De_Pessoas.APPLICATION.Models.Request;
using Cadastro_De_Pessoas.APPLICATION.Models.Response.PessoaResponse;
using Cadastro_De_Pessoas.DOMAIN;
using Cadastro_De_Pessoas.INFRA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Services.PessoaService
{
    public class PessoaService : IPessoaService
    {
        private readonly DataContext _context;
        public PessoaService(DataContext context)
        {
            _context = context;
        }

        public async Task<CreatePessoaResponse> CreateAsync(PessoaRequest pessoaRequest)
        {
            var newPessoa = Pessoa.Create(pessoaRequest.Nome, pessoaRequest.Cpf, pessoaRequest.Idade, pessoaRequest.CidadeId);

            await _context.Pessoas.AddAsync(newPessoa);

            _context.SaveChangesAsync();

            return new CreatePessoaResponse() { Id = newPessoa.Id, Message = "Pessoa cadastrada com sucesso!" };
        }

        public async Task<DeletePessoaResponse> DeleteAsync(int id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

            if (pessoa != null)
            {
                _context.Remove(pessoa);
                await _context.SaveChangesAsync();

                return new DeletePessoaResponse() { Message = "Pessoa removida com sucesso!" };
            }

            return new DeletePessoaResponse();
        }

        public async Task<GetAllPessoaResponse> GetAllAsync()
        {
            var listPessoas = await _context.Pessoas.ToListAsync();

            return new GetAllPessoaResponse()
            {
                Pessoas = listPessoas != null ? listPessoas.Select(a => (PessoaDto)a).ToList() : new List<PessoaDto>().ToList()
            };
        }

        public async Task<GetByIdPessoaResponse> GetByIdAsync(int id)
        {
            var pessoaResponse = new GetByIdPessoaResponse();

            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            if (pessoa != null) pessoaResponse.Pessoa = (PessoaDto)pessoa;

            return pessoaResponse;
        }

        public async Task<UpdatePessoaResponse> UpdateAsync(int id, PessoaRequest pessoaRequest)
        {
 
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            if(pessoa != null)
            {
                pessoa.Update(pessoaRequest.Nome, pessoaRequest.Cpf, pessoaRequest.Idade, pessoaRequest.CidadeId);
                await _context.SaveChangesAsync();
                return new UpdatePessoaResponse() { Message = "Pessoa atualizado com sucesso!" };
            }

            return new UpdatePessoaResponse();
        }
    }
}
