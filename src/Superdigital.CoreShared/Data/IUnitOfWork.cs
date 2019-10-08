using System.Threading.Tasks;

namespace Superdigital.CoreShared.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}