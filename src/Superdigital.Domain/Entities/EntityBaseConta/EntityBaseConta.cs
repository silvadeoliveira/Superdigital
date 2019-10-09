using System;
using Superdigital.CoreShared.DomainObjects;

namespace Superdigital.Domain.Entities.EntityBaseConta
{
    public abstract class EntityBaseConta<T> : Entity
    {

        public Guid TitularId { get; protected set; }
        public DateTime DataAberturaConta { get; protected set; }
        public decimal Saldo { get; protected set; }
        public abstract bool Saca(decimal valor);
        public abstract bool Deposito(decimal valor);
    }
}