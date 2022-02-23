using SistemaCompra.Domain.Interfaces.Repository;
using System;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public Domain.SolicitacaoCompraAggregate.SolicitacaoCompra RegistrarCompra(Domain.SolicitacaoCompraAggregate.SolicitacaoCompra solicitacaoCompra)
        {
            context.Add(solicitacaoCompra);
            context.SaveChanges();
            return solicitacaoCompra;
        }
    }
}
