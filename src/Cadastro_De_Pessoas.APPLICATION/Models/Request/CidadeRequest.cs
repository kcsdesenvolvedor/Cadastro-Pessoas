using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.APPLICATION.Models.Request
{
    public class CidadeRequest
    {
        [Required(ErrorMessage = "O campo Nome é Obrigatório!")]
        [MinLength(3, ErrorMessage = "O campo deve conter entre 3 e 200 caracteres!")]
        [MaxLength(200, ErrorMessage = "O campo deve conter entre 3 e 200 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo UF é Obrigatório!")]
        [MinLength(2, ErrorMessage = "O campo deve conter 2 caracteres!")]
        [MaxLength(2, ErrorMessage = "O campo deve conter 2 caracteres!")]
        public string UF { get; set; }
    }
}
