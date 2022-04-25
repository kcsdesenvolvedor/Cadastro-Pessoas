using Cadastro_De_Pessoas.DOMAIN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_De_Pessoas.INFRA.Map
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas")
                .HasOne(p => p.Cidade)
                .WithMany()
                .HasForeignKey(p => p.CidadeId);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(p => p.CidadeId).IsRequired();

        }
    }
}
