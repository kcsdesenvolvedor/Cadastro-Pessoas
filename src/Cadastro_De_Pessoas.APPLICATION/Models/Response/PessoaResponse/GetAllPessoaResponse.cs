using Cadastro_De_Pessoas.APPLICATION.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Models.Response.PessoaResponse
{
    public class GetAllPessoaResponse
    {
        public List<PessoaDto> Pessoas { get; set; }
    }
}
