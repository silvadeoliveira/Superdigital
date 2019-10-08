using System;
using System.Threading.Tasks;
using Superdigital.CoreShared.DomainObjects;

namespace Superdigital.CoreShared.Data
{
    public interface IRepository <T> : IDisposable where T : IAggregateRoot
    {
        Task<T> Find(Guid id);
        Task<T> Add(T entidade);
        void Update(T entidade);
        void Remove(T entidade);
        IUnitOfWork UnitOfWork { get; }
    }
}