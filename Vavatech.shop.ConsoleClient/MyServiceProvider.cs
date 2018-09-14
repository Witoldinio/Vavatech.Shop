using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.ConsoleClient
{
    public abstract class MyServiceProvider
    {
        private static IServiceProvider _provider;

        public static void RegisterServiceProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public static IServiceProvider GetServiceProvider()
        {
            return _provider;
        }
    }
}
