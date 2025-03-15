using Code.Gameplay.Features;
using Code.Infrastructure.Factory;
using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Infrastructure.States.GameStates
{
  public class GameLoopState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systemFactory;
    
    private GameplayFeature _gameplayFeature;
    private readonly GameContext _gameContext;

    public GameLoopState(ISystemFactory systemFactory, GameContext gameContext)
    {
      _systemFactory = systemFactory;
      _gameContext = gameContext;
    }

    public override void Enter()
    {
      _gameplayFeature = _systemFactory.Create<GameplayFeature>();
      _gameplayFeature.Initialize();
    }

    protected override void Update()
    {
      _gameplayFeature.Execute();
      _gameplayFeature.Cleanup();
    }

    protected override void ExitOnEndOfFrame()
    {
      _gameplayFeature.ClearReactiveSystems();
      _gameplayFeature.DeactivateReactiveSystems();

      DestructEntities();

      _gameplayFeature.Cleanup();
      _gameplayFeature.TearDown();
      _gameplayFeature = null;
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities())
        entity.isDestructed = true;
    }
  }
}
