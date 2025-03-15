using Code.Infrastructure.States.StateInfrastructure;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class GameLoopState : EndOfFrameExitState
  {
    public override void Enter()
    {
      Debug.Log("Game started!");
    }
  }
}
