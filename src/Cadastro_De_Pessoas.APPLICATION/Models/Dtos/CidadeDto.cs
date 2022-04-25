using Cadastro_De_Pessoas.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Models.Dtos
{
    public class CidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public static explicit operator CidadeDto(Cidade cidade)
        {
            return new CidadeDto()
            {
                Id = cidade.Id,
                Nome = cidade.Nome,
                UF = cidade.UF,
            };
        }
    }
}
