using Autofac;
using DataBase;

namespace Repository {
    public class RepositoryModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<ContextRepository<Storage>>().As<IGenericRepository<Storage>>();
            builder.RegisterType<ContextRepository<Folder>>().As<IGenericRepository<Folder>>();
            builder.RegisterType<ContextRepository<File>>().As<IGenericRepository<File>>();
        }
    }
}