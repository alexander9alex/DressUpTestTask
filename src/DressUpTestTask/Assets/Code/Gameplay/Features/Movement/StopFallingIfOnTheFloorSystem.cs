using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
  public class StopFallingIfOnTheFloorSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _falling;
    private readonly List<GameEntity> _buffer = new(1);

    public StopFallingIfOnTheFloorSystem(GameContext game)
    {
      _falling = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Falling,
          GameMatcher.OnTheFloor
        )
        .NoneOf(
          GameMatcher.Selected,
          GameMatcher.CantLocate
        ));
    }

    public void Execute()
    {
      foreach (GameEntity falling in _falling.GetEntities(_buffer))
      {
        falling.isFalling = false;
      }
    }
  }
}
