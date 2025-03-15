using Code.Gameplay.Common;
using Code.Gameplay.Common.Services;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private const int TargetFrameRate = 60;

    private readonly IGameStateMachine _gameStateMachine;
    private readonly IStaticDataService _staticData;

    public BootstrapState(IGameStateMachine gameStateMachine, IStaticDataService staticData)
    {
      _gameStateMachine = gameStateMachine;
      _staticData = staticData;
    }

    public override void Enter()
    {
      Application.targetFrameRate = TargetFrameRate;
      
      _staticData.LoadAll();
      
      _gameStateMachine.Enter<LoadingGameState>();
    }
  }
}
