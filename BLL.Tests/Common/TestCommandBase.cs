using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using UoW;
using Repository;

namespace BLL.Tests {
    public abstract class TestCommandBase : IDisposable {
        protected readonly ContentLibraryContext context;
        private readonly IGenericRepository<Storage> storageR;
        private readonly IGenericRepository<Folder> folderR;
        private readonly IGenericRepository<File> fileR;
        public IUnitOfWork unitOfWork;

        public TestCommandBase() {
            context = ContextFactory.Create();
            storageR = new ContextRepository<Storage>(context);
            folderR = new ContextRepository<Folder>(context);
            fileR = new ContextRepository<File>(context);
            unitOfWork = new UnitOfWork(context, storageR, folderR, fileR);
        }

        public void Dispose() => ContextFactory.Destroy(context);
    }
}