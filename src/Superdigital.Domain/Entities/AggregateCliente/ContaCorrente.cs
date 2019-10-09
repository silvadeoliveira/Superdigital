using System;
using Superdigital.CoreShared.Enum;
using Superdigital.Domain.Entities.EntityBaseConta;


namespace Superdigital.Domain.Entities.AggregateCliente
{
    public class ContaCorrente : EntityBaseConta<ContaCorrente>
    {
        protected ContaCorrente(){}

        public ContaCorrente(decimal saldo, Guid titularId)
        {
            Saldo = saldo;
            TitularId = titularId;
            TipoContaId = (int)TipoConta.ContaCorrente;
        }


        public Guid TitularId { get; private set; }
        public bool Ativo { get; private set; }

        // EF propriedades de navegacao
        public Cliente TitutalarConta { get; }
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

        public static class ContaCorrenteFactory
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
            public static ContaCorrente FecharContaCorrente(Guid titularId)
            {
                var contaCorrente = new ContaCorrente
                {
                    TitularId = titularId,
                    Ativo = false
                    
                };

                return contaCorrente;

            }
        }
    }



}