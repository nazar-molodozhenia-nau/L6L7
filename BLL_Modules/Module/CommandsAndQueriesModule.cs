using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using CommandsAndQueries;
using System.Reflection;

namespace BLL_Modules {
    public class CommandsAndQueriesModule : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterMediatR(typeof(AddStorageCommandHandler).GetTypeInfo().Assembly);
            builder.RegisterMediatR(typeof(GetStorageQueryHandler).GetTypeInfo().Assembly);
        }
    }
}