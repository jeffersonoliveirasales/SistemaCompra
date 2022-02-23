using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.Interfaces.Repository
{
    public interface ISolicitacaoCompraRepository
    {
        SolicitacaoCompra RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
