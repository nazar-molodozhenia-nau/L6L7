using Autofac;
using AutoMapper;
using ViewModels;
using CommandsAndQueries;


namespace UI.WebAPI
{
    public class ModelMappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StorageMapper>();
                cfg.AddProfile<FolderMapper>();
                cfg.AddProfile<FileMapper>();
                cfg.AddProfile<StorageModelMapper>();
                cfg.AddProfile<FileModelMapper>();
                cfg.AddProfile<FolderModelMapper>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
