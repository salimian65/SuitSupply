﻿namespace SuitSupply.Framework.Core.DependencyInjection
{
    public static class ServiceLocator
    {
        public static void Initial(IContainer container)
        {
            if (Current == null)
            {
                Current = container;
            }
        }

        public static void InitialForTestMode(IContainer container)
        {
            Current = container;
        }

        public static IContainer Current { get; private set; }
    }
}