using Cadastro_De_Pessoas.APPLICATION.Models.Request;
using Cadastro_De_Pessoas.APPLICATION.Models.Response.CidadeResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Services.CidadeService
{
    public interface ICidadeService
    {
        Task<GetAllCidadeResponse> GetAllAsync();
        Task<GetByIdCidadeResponse> GetByIdAsync(int id);
        Task<CreateCidadeResponse> CreateAsync(CidadeRequest cidadeRequest);
        Task<UpdateCidadeResponse> UpdateAsync(int id, CidadeRequest cidadeRequest);
        Task<DeleteCidadeResponse> DeleteAsync(int id);
    }
}
