using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadingGameState : SimpleState
  {
    private readonly IGameStateMachine _gameStateMachine;

    public LoadingGameState(IGameStateMachine gameStateMachine) =>
      _gameStateMachine = gameStateMachine;

    public override void Enter() =>
      _gameStateMachine.Enter<GameLoopState>();
  }
}
