using api.Data.Repos.Interfaces;

namespace api.Data.Interface
{
    public interface IUnitOfWork
    {
        ICustomerRepo CustomerRepo { get; }

        void Save();
    }
}