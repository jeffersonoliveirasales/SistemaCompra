using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class CondicaoPagamento
    {
        private IList<int> _valoresPossiveis = new List<int>() { 0, 30, 60, 90 };
        public int Valor { get; private set; }

        private CondicaoPagamento(){}

        public CondicaoPagamento(int condicao, Money totalGeral = null)
        {
            if (!_valoresPossiveis.Contains(condicao)) throw new BusinessRuleException("Condição de pagamento deve ser " + _valoresPossiveis.ToString());

            if (totalGeral.Value > 50000 && condicao != 30)
            {
                throw new BusinessRuleException("Condição de pagamento para valores acima de 50000 deve ser 30 dias");
            }

            Valor = condicao;
        }
    }
}