using Code.Gameplay.Common;
using Code.Gameplay.Common.Services;
using Code.Gameplay.Locations.Factory;
using Code.Infrastructure.Common;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Views.Factory;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
  {
    public override void InstallBindings()
    {
      BindInfrastructureFactories();
      BindInfrastructureServices();
      BindGameFactories();
      BindGameServices();
      BindGameStateFactory();
      BindContexts();
      BindGameStates();
      BindGameStateMachine();
    }

    private void BindInfrastructureFactories() =>
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

    private void BindInfrastructureServices() =>
      Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();

    private void BindGameFactories()
    {
      Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
      Container.Bind<ILocationFactory>().To<LocationFactory>().AsSingle();
    }

    private void BindGameServices()
    {
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
    }

    private void BindGameStateFactory() =>
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

    private void BindContexts()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }

    private void BindGameStates()
    {
      Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadingGameState>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
    }

    private void BindGameStateMachine() =>
      Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

    public void Initialize() =>
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
  }
}
