using Cadastro_De_Pessoas.APPLICATION.Models.Dtos;
using Cadastro_De_Pessoas.APPLICATION.Models.Request;
using Cadastro_De_Pessoas.APPLICATION.Models.Response.CidadeResponse;
using Cadastro_De_Pessoas.APPLICATION.Services.PessoaService;
using Cadastro_De_Pessoas.DOMAIN;
using Cadastro_De_Pessoas.INFRA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Services.CidadeService
{
    public class CidadeService : ICidadeService
    {
        private readonly DataContext _context;
        private readonly IPessoaService _pessoaService;
        public CidadeService(DataContext context, IPessoaService pessoaService)
        {
            _context = context;
            _pessoaService = pessoaService;
        }
        public async Task<CreateCidadeResponse> CreateAsync(CidadeRequest cidadeRequest)
        {
            var newCidade = Cidade.Create(cidadeRequest.Nome, cidadeRequest.UF);

            await _context.Cidades.AddAsync(newCidade);
            await _context.SaveChangesAsync();

            return new CreateCidadeResponse() { Id = newCidade.Id, Message = "Cidade cadastrada com sucesso!"};
        }

        public async Task<DeleteCidadeResponse> DeleteAsync(int id)
        {
            var cidade = await _context.Cidades.FirstOrDefaultAsync(c => c.Id == id);
            
            if(cidade != null)
            {
                var isPessoa = VerificarRelacaoPessoaCidade(cidade);
                if (isPessoa != null)
                {
                    return new DeleteCidadeResponse() { Message = "Existe uma ou mais pessoas vinculada a essa cidade!"};
                }
                _context.Remove(cidade);
                await _context.SaveChangesAsync();
                return new DeleteCidadeResponse() { Message = "Cidade removida com sucesso!" };
            }

            return new DeleteCidadeResponse();
        }

        public async Task<GetAllCidadeResponse> GetAllAsync()
        {
            var cidadeList = await _context.Cidades.ToListAsync();

            return new GetAllCidadeResponse()
            {
                Cidades = cidadeList != null ? cidadeList.Select(c => (CidadeDto)c).ToList() : new List<CidadeDto>().ToList()
            };
        }

        public async Task<GetByIdCidadeResponse> GetByIdAsync(int id)
        {
            var cidadeResponse = new GetByIdCidadeResponse();

            var cidade = await _context.Cidades.FirstOrDefaultAsync(c => c.Id == id);
            if (cidade != null) cidadeResponse.Cidade = (CidadeDto)cidade;

            return cidadeResponse; 
        }

        public async Task<UpdateCidadeResponse> UpdateAsync(int id, CidadeRequest cidadeRequest)
        {
            var cidade = await _context.Cidades.FirstOrDefaultAsync(c => c.Id == id);

            if(cidade != null)
            {
                cidade.Update(cidadeRequest.Nome, cidadeRequest.UF);
                await _context.SaveChangesAsync();
                return new UpdateCidadeResponse() { Message = "Cidade atualizada com sucesso!" };
            }

            return new UpdateCidadeResponse();
        }

        private Pessoa VerificarRelacaoPessoaCidade(Cidade cidade)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.CidadeId == cidade.Id);

            return pessoa;
        }
    }
}
