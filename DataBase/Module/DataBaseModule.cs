using Autofac;

namespace DataBase
{
    public class DataBaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentLibraryContext>().
                WithParameter("options", DbContextOptionsFactory.Get()).AsSelf().SingleInstance();
        }
    }
}
