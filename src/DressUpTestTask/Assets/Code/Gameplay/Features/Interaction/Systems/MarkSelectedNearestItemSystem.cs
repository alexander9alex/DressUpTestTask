using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Interaction.Systems
{
  public class MarkSelectedNearestItemSystem : IExecuteSystem
  {
    private const float TouchRadius = 0.05f;
    private readonly int _itemsLayerMask = LayerMask.GetMask("Item");

    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _interactions;

    public MarkSelectedNearestItemSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _interactions = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.InteractionStarted,
          GameMatcher.MousePosition
        ));
    }

    public void Execute()
    {
      foreach (GameEntity interaction in _interactions)
      foreach (GameEntity entity in GetNearestEntities(interaction.MousePosition))
      {
        if (entity is { isItem: true })
          entity.isSelected = true;
      }
    }

    private IEnumerable<GameEntity> GetNearestEntities(Vector2 mousePos) =>
      _physicsService.CircleCast(ScreenToWorldPos(mousePos), TouchRadius, _itemsLayerMask);

    private static Vector3 ScreenToWorldPos(Vector2 mousePos) =>
      Camera.main.ScreenToWorldPoint(mousePos);
  }
}
