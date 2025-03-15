using Code.Gameplay.Features.Input.Commands;
using Code.Gameplay.Features.Input.Services;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class SetInteractionStartedMousePositionSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<GameEntity> _inputs;

    public SetInteractionStartedMousePositionSystem(GameContext game)
    {
      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.InteractionStarted,
          GameMatcher.MousePosition
        ));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        input.ReplaceInteractionStartedMousePosition(input.MousePosition);
      }
    }
  }
}
