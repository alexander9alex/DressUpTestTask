using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Interaction.Systems
{
  public class UnselectSelectedItemsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _interactions;
    private readonly IGroup<GameEntity> _items;
    private readonly List<GameEntity> _buffer = new(1);

    public UnselectSelectedItemsSystem(GameContext game)
    {
      _interactions = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.InteractionEnded
        ));

      _items = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Item,
          GameMatcher.Selected
        ));
    }

    public void Execute()
    {
      foreach (GameEntity _ in _interactions)
      foreach (GameEntity item in _items.GetEntities(_buffer))
      {
        item.isSelected = false;
      }
    }
  }
}
