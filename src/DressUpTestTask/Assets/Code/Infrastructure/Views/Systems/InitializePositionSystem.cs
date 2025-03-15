using System.Collections.Generic;
using Entitas;

namespace Code.Infrastructure.Views.Systems
{
  public class InitializePositionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(64);

    public InitializePositionSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.InitializePosition, GameMatcher.Transform, GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.Transform.position = entity.WorldPosition;

        entity.isInitializePosition = false;
      }
    }
  }
}
