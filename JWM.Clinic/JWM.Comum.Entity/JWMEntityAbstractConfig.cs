using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JWM.Comum.Entity
{
    public abstract class JWMEntityAbstractConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public JWMEntityAbstractConfig()
        {

            ConfigurarNomeTabela();
            ConfigurarCamposTabela();
            ConfigurarChavePrimaria();
            ConfigurarChavesEstrangeiras();

        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
