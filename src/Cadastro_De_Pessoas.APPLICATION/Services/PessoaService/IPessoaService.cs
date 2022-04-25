using Cadastro_De_Pessoas.APPLICATION.Models.Request;
using Cadastro_De_Pessoas.APPLICATION.Models.Response.PessoaResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Services.PessoaService
{
    public interface IPessoaService
    {
        Task<GetAllPessoaResponse> GetAllAsync();
        Task<GetByIdPessoaResponse> GetByIdAsync(int id);
        Task<CreatePessoaResponse> CreateAsync(PessoaRequest pessoaRequest);
        Task<UpdatePessoaResponse> UpdateAsync(int id, PessoaRequest pessoaRequest);
        Task<DeletePessoaResponse> DeleteAsync(int id);
    }
}
