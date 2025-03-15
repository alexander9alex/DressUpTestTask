using Code.Gameplay.Locations.Data;
using Code.Gameplay.Locations.Factory;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadingGameState : SimpleState
  {
    private const string GameScene = "Game";

    private readonly IGameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly ILocationFactory _locationFactory;

    public LoadingGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILocationFactory locationFactory)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _locationFactory = locationFactory;
    }

    public override void Enter() =>
      _sceneLoader.LoadScene(GameScene, OnLoaded);

    private void OnLoaded()
    {
      _locationFactory.CreateLocation(LocationId.Room);

      _gameStateMachine.Enter<GameLoopState>();
    }
  }
}
