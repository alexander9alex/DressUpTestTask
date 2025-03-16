using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Interaction.Systems
{
  public class PlaceItemInZoneSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _interactions;
    private readonly IGroup<GameEntity> _items;
    private readonly List<GameEntity> _buffer = new(1);

    public PlaceItemInZoneSystem(GameContext game)
    {
      _interactions = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.InteractionEnded
        ));

      _items = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Item,
          GameMatcher.Selected,
          GameMatcher.InCanPlaceItemZone
        ).NoneOf(GameMatcher.InCantPlaceItemZone));
    }

    public void Execute()
    {
      foreach (GameEntity _ in _interactions)
      foreach (GameEntity item in _items.GetEntities(_buffer))
      {
        item.isFalling = false;
      }
    }
  }
}
