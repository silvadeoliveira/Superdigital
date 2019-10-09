using System;
using FluentValidation;
using FluentValidation.Results;
using Superdigital.CoreShared.DomainObjects;
using Superdigital.Domain.Enum;

namespace Superdigital.Domain.Entities.AggregateCliente
{
    public class Transacao : Entity
    {
        public Transacao(TipoTransacaoEnum tipoTransacao, Guid numeroContaOrigem, Guid numeroContaDestino, double valor)
        {
            TipoTransacao = tipoTransacao;
            DtTransacao = DateTime.Now;
            NumeroContaOrigem = numeroContaOrigem;
            NumeroContaDestino = numeroContaDestino;
            Valor = valor;
        }
        public TipoTransacaoEnum TipoTransacao { get; private set; }
        public DateTime DtTransacao { get; private set; }
        public Guid NumeroContaOrigem { get; private set; }
        public Guid NumeroContaDestino { get; private set; }

        public double Valor { get; private set; }
        public ValidationResult ValidarTrasferencia()
        {
            return new TransacaoAplicavelValidation().Validate(this);
        }


    }


    internal class TransacaoAplicavelValidation : AbstractValidator<Transacao>
    {
        public TransacaoAplicavelValidation()
        {
            RuleFor(c => c.NumeroContaOrigem)
                .Must(ValidadeNumeroContaOrigem)
                .WithMessage("Número de Conta Origem é inválido.");

            RuleFor(c => c.NumeroContaDestino)
                .Must(ValidadeNumeroContaDestino)
                .WithMessage("Número de Conta Destino é inválido.");

            RuleFor(c => c.Valor)
                .ExclusiveBetween(1, 50000)
                .WithMessage("O valor deve estar entre 1.00 e 50.000");
        }

        private static bool ValidadeNumeroContaOrigem(Guid numeroConta)
        {
            return numeroConta.Equals(Guid.Empty);
        }

        private static bool ValidadeNumeroContaDestino(Guid numeroConta)
        {
            return numeroConta.Equals(Guid.Empty);
        }
    }
}