using Cadastro_De_Pessoas.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Models.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public int CidadeId { get; set; }

        public static explicit operator PessoaDto(Pessoa pessoa)
        {
            return new PessoaDto()
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Cpf = pessoa.Cpf,
                Idade = pessoa.Idade,
                CidadeId = pessoa.CidadeId,
            };
        }
    }
}
