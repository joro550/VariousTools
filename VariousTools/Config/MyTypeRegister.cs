

using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace VariousTools.Config;

public class MyTypeRegister : ITypeRegistrar
{
    public class MyTypeResolver : ITypeResolver
    {
        private readonly ServiceProvider _provider;

        public MyTypeResolver(ServiceProvider provider) 
            => _provider = provider;

        public object? Resolve(Type? type) 
            => type == null ? null : _provider.GetService(type);
    }
    
    private readonly ServiceCollection _serviceCollection;

    public MyTypeRegister(ServiceCollection serviceCollection) 
        => _serviceCollection = serviceCollection;

    public void Register(Type service, Type implementation) 
        => _serviceCollection.AddTransient(service, implementation);

    public void RegisterInstance(Type service, object implementation)
        => _serviceCollection.AddTransient(service, _ => implementation);
    

    public void RegisterLazy(Type service, Func<object> factory)
        => _serviceCollection.AddTransient(service, _ => factory());

    public ITypeResolver Build() 
        => new MyTypeResolver(_serviceCollection.BuildServiceProvider());
}