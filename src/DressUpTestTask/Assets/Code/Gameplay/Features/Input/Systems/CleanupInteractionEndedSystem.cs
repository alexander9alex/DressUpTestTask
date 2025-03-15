using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class CleanupInteractionEndedSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer = new(1);

    public CleanupInteractionEndedSystem(GameContext game)
    {
      _group = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.InteractionEnded
        ));
    }

    public void Cleanup()
    {
      foreach (GameEntity input in _group.GetEntities(_buffer))
      {
        input.isInteractionEnded = false;
      }
    }
  }

  public class CleanupInteractionStartedMousePositionSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer = new(1);

    public CleanupInteractionStartedMousePositionSystem(GameContext game)
    {
      _group = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.InteractionEnded,
          GameMatcher.InteractionStartedMousePosition
        ));
    }

    public void Cleanup()
    {
      foreach (GameEntity input in _group.GetEntities(_buffer))
      {
        input.RemoveInteractionStartedMousePosition();
      }
    }
  }
}
