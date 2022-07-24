using System;
using System.Linq;
using Autofac;
using SpecFlow.Autofac;
using SpecFlow.Autofac.SpecFlowPlugin;
using TechTalk.SpecFlow;

namespace SuitSupply.Tailoring.E2ETests.Technical.Dependencies
{
    public static class AutofacTestDependencyProvider
    {
        [GlobalDependencies]
        public static void CreateContainerBuilder(ContainerBuilder builder)
        {
            TestDependencies.CreateContainerBuilder(builder);
        }

        [ScenarioDependencies]
        public static void CreateContainerBuilder2(ContainerBuilder builder)
        {
           // TestDependencies.CreateContainerBuilder(builder);
            builder.RegisterTypes(typeof(AutofacTestDependencyProvider).Assembly.
                GetTypes().
                Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).
                ToArray()).
                SingleInstance();
        }
    }
}
