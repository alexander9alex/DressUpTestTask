using Entitas;
using Zenject;

namespace Code.Infrastructure.Factory
{
  class SystemFactory : ISystemFactory
  {
    private readonly DiContainer _container;

    public SystemFactory(DiContainer container) =>
      _container = container;

    public TSystem Create<TSystem>() where TSystem : ISystem =>
      _container.Instantiate<TSystem>();
  }
}
