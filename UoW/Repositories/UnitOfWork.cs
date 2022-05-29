using System;
using Repository;
using DataBase;
using System.Threading.Tasks;
using System.Threading;

namespace UoW {
    public class UnitOfWork : IUnitOfWork {

        private readonly ContentLibraryContext context;

        public IGenericRepository<Storage> Storage { get; set; }
        public IGenericRepository<Folder> Folder { get; set; }
        public IGenericRepository<File> File { get; set; }

        public UnitOfWork(ContentLibraryContext context, IGenericRepository<Storage> storage, IGenericRepository<Folder> folder, IGenericRepository<File> file) {
            this.context = context; Storage = storage; Folder = folder; File = file; }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) { if(!this.disposed) { if(disposing) { context.Dispose(); } this.disposed = true; } }
        
        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }

        public async Task SaveAsync(CancellationToken cancellationToken) { await context.SaveChangesAsync(cancellationToken); }

    }
}