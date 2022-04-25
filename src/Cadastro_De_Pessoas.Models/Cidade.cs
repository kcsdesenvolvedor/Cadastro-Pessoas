using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.DOMAIN
{
    public sealed class Cidade
    {
        private Cidade()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public static Cidade Create(string nome, string uf)
        {
            return new Cidade() { Nome = nome, UF = uf};
        }

        public void Update(string nome, string uf)
        {
            Nome = nome;
            UF = uf;
        }
    }
}
