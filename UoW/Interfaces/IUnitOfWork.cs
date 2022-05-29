using System;
using Repository;
using DataBase;
using System.Threading.Tasks;
using System.Threading;

namespace UoW {
    public interface IUnitOfWork : IDisposable {
        IGenericRepository<Storage> Storage { get; }
        IGenericRepository<Folder> Folder { get; }
        IGenericRepository<File> File { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}