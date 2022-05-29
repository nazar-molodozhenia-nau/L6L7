using System;
using System.Collections.Generic;
using DataBase;
using UoW;
using Repository;
using AutoMapper;
using CommandsAndQueries;
using UI.WebAPI;
using Xunit;


namespace BLL.Tests
{
    public class QueryTestFixture : IDisposable
    {
        private readonly ContentLibraryContext context;
        private readonly IGenericRepository<Storage> storageR;
        private readonly IGenericRepository<Folder> folderR;
        private readonly IGenericRepository<File> fileR;
        public IUnitOfWork unitOfWork;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = ContextFactory.Create();
            storageR = new ContextRepository<Storage>(context);
            folderR = new ContextRepository<Folder>(context);
            fileR = new ContextRepository<File>(context);

            unitOfWork = new UnitOfWork(context, storageR, folderR, fileR);
            var configurationProvider = new MapperConfiguration(cfg =>
            cfg.AddProfiles(new List<Profile>()
            {

                new StorageMapper(),
                new FolderMapper(),
                new FileMapper(),
                new WorkoutMapper(),

                new StorageModelMapper(),
                new FileModelMapper(),
                new FolderModelMapper(),
            }));
            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() => ContextFactory.Destroy(context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
