using MediatR;
using SistemaCompra.Domain.Interfaces.Repository;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using solicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoRepository, IUnitOfWork uow, 
            IMediator mediator, IProdutoRepository produtoRepository) : base(uow, mediator)
        {
            _solicitacaoRepository = solicitacaoRepository;
            _produtoRepository = produtoRepository;
        }
        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {

            foreach (solicitacaoAgg.Item item in request.itens)
            {
                item.Produto = _produtoRepository.Obter(item.Produto.Id);
            }
            var solicitacaoCompra = new solicitacaoAgg.SolicitacaoCompra(request.usuarioSolicitante, request.nomeFornecedor, request.itens, request.condicaoPagamento);

            _solicitacaoRepository.RegistrarCompra(solicitacaoCompra);

            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}
