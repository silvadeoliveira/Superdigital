using System;
using Superdigital.CoreShared.DomainObjects;
using Superdigital.Domain.Entities.AggregatePessoa;
using Superdigital.Domain.Entities.EntityBaseConta;
using Superdigital.Domain.Enum;

namespace Superdigital.Domain.Entities.AggregateConta
{
    public class ContaCorrente : EntityBaseConta<ContaCorrente>, IAggregateRoot
    {
        protected ContaCorrente(){}

        public ContaCorrente(decimal saldo, Guid titularId)
        {
            Saldo = saldo;
            TitularId = titularId;
            TipoContaId = (int)TipoConta.ContaCorrente;
        }
        public bool Ativo { get; private set; }

        // EF propriedades de navegacao
        public Pessoa TitutalarConta { get; private set; }
        public int TipoContaId { get; private set; }

        public override bool Saca(decimal valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                return true;
            }
            return false;
        }

        public override bool Deposito(decimal valor)
        {
            if (valor < 0)
            {
                Saldo += valor;
                return true;
            }

            return false;

        }

        public static class PedidoFactory
        {
            public static ContaCorrente NovaContaCorrente(decimal saldo, Guid titularId)
            {
                var  contaCorrente = new ContaCorrente
                {
                    TitularId = titularId,
                    DataAberturaConta = DateTime.Now,
                    Saldo = saldo
                };

                return contaCorrente;

            }
        }
    }



}