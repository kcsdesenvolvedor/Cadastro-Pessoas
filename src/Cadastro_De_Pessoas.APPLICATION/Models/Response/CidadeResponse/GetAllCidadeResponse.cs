using Cadastro_De_Pessoas.APPLICATION.Models.Dtos;
using Cadastro_De_Pessoas.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Models.Response.CidadeResponse
{
    public class GetAllCidadeResponse
    {
        public List<CidadeDto> Cidades { get; set; }
    }
}
