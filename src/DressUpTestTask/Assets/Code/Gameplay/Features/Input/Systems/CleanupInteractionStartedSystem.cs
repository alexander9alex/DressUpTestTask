using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class CleanupInteractionStartedSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer = new(1);

    public CleanupInteractionStartedSystem(GameContext game)
    {
      _group = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.InteractionStarted
        ));
    }

    public void Cleanup()
    {
      foreach (GameEntity input in _group.GetEntities(_buffer))
      {
        input.isInteractionStarted = false;
      }
    }
  }
}
