using SuitSupply.Tailoring.E2ETests.Technical.APIs;
using SuitSupply.Tailoring.E2ETests.Technical.Contracts;
using SuitSupply.Tailoring.E2ETests.Technical.Persistence.ReadModel;
using SuitSupply.Tailoring.E2ETests.Technical.Persistence.WriteModel;
using SuitSupply.Tailoring.E2ETests.Technical.Transporters;
using SuitSupply.Tailoring.E2ETests.Technical.Utilities;
using Autofac;

namespace SuitSupply.Tailoring.E2ETests.Technical.Dependencies
{
    public static class TestDependencies
    {
        public static ContainerBuilder CreateContainerBuilder(ContainerBuilder builder)
        {
            builder.RegisterType<AlteringTaskEndpoint>().As<IAlteringTaskEndpoint>().SingleInstance();
            builder.RegisterType<WriteModelRepository>().As<IWriteModelRepository>().SingleInstance();
            builder.RegisterType<ReadModelRepository>().As<IReadModelRepository>().SingleInstance();
            builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
            builder.RegisterType<StanConnectionFactory>().SingleInstance();
            return builder;
        }
    }
}
