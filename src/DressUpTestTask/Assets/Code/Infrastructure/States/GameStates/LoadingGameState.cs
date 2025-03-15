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

    public LoadingGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
    }

    public override void Enter() =>
      _sceneLoader.LoadScene(GameScene, OnLoaded);

    private void OnLoaded() =>
      _gameStateMachine.Enter<GameLoopState>();
  }
}
