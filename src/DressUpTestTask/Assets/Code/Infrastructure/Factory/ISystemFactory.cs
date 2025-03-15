using Entitas;

namespace Code.Infrastructure.Factory
{
  public interface ISystemFactory
  {
    TSystem Create<TSystem>() where TSystem : ISystem;
  }
}
