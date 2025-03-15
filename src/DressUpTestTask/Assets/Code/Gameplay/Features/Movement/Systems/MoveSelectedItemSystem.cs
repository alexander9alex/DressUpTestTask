using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class MoveSelectedItemSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _items;
    private readonly IGroup<GameEntity> _inputs;

    public MoveSelectedItemSystem(GameContext game)
    {
      _items = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Item,
          GameMatcher.Selected,
          GameMatcher.WorldPosition
        ));

      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.MousePosition,
          GameMatcher.InteractionStartedMousePosition
        ));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      foreach (GameEntity item in _items)
      {
        item.ReplaceWorldPosition(CalculateNewPosition(item, input));
      }
    }

    private static Vector2 CalculateNewPosition(GameEntity item, GameEntity input) =>
      item.PositionBeforeSelecting + (ScreenToWorldPos(input.MousePosition) - ScreenToWorldPos(input.InteractionStartedMousePosition));

    private static Vector3 ScreenToWorldPos(Vector2 mousePos) =>
      Camera.main.ScreenToWorldPoint(mousePos);
  }
}
