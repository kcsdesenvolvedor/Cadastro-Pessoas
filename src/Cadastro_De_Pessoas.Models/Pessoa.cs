using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro_De_Pessoas.DOMAIN
{
    public sealed class Pessoa
    {
        private Pessoa(string nome, string cpf, int idade, int cidadeId)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Idade = idade;
            this.CidadeId = cidadeId;

        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public int CidadeId { get; set; }
        public Cidade? Cidade { get; set; }

        public static Pessoa Create(string nome, string cpf, int idade, int cidadeId) 
        {
            return new Pessoa(nome, cpf, idade, cidadeId);
        }

        public void Update(string nome, string cpf, int idade, int cidadeId)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            CidadeId = cidadeId;
        }
    }
}