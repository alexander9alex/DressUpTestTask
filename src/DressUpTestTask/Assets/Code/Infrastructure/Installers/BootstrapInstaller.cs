using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoInstaller, IInitializable
  {
    public override void InstallBindings()
    {
      BindInfrastructureServices();
      BindGameStateFactory();
      BindGameStates();
      BindGameStateMachine();
    }

    private void BindInfrastructureServices() =>
      Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();

    private void BindGameStateFactory() =>
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

    private void BindGameStates()
    {
      Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadingGameState>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
    }

    private void BindGameStateMachine() =>
      Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

    public void Initialize() =>
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
  }
}
