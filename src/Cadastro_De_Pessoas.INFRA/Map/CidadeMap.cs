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
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidades")
                .HasKey(c => c.Id);

            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(200);
            builder.Property(c => c.UF).IsRequired().HasMaxLength(2);
        }
    }
}
