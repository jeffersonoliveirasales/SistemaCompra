﻿using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string usuarioSolicitante { get; set; }

        public string nomeFornecedor { get; set; }
        public IList<Item> itens { get; set; }
        public int condicaoPagamento { get; set; }
    }
}
