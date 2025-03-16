using System.Numerics;
using Entitas;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Code.Gameplay.Features.Movement
{
  public class MoveDownFallingSystem : IExecuteSystem
  {
    private const float FallingSpeed = 9.81f;

    private readonly IGroup<GameEntity> _falling;

    public MoveDownFallingSystem(GameContext game)
    {
      _falling = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Falling,
          GameMatcher.WorldPosition
        )
        .NoneOf(GameMatcher.Selected));
    }

    public void Execute()
    {
      foreach (GameEntity falling in _falling)
      {
        falling.ReplaceWorldPosition(falling.WorldPosition + Vector3.down * FallingSpeed * Time.deltaTime);
      }
    }
  }
}
