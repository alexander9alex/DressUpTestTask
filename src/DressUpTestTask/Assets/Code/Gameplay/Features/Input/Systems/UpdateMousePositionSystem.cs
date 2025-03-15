using Code.Gameplay.Features.Input.Services;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class UpdateMousePositionSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<GameEntity> _inputs;

    public UpdateMousePositionSystem(GameContext game, IInputService inputService)
    {
      _inputService = inputService;
      _inputs = game.GetGroup(GameMatcher.Input);
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        input.ReplaceMousePosition(_inputService.GetMousePosition());
      }
    }
  }
}
