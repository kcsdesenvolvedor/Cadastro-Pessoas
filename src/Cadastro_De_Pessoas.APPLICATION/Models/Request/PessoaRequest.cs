using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Models.Request
{
    public class PessoaRequest
    {

        [Required(ErrorMessage = "O campo Nome é Obrigatório!")]
        [MinLength(3, ErrorMessage = "Esse campo deve ter entre 3 e 300 caracteres!")]
        [MaxLength(300, ErrorMessage = "Esse campo deve ter entre 3 e 300 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Cpf é Obrigatório!")]
        [MinLength(11, ErrorMessage = "O campo Cpf deve ter 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O campo Cpf deve ter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Idade é Obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "A idade deve ser maior que zero!")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo Cidade é Obrigatório!")]
        public int CidadeId { get; set; }
    }
}
