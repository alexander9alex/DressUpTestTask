using Code.Gameplay.Features.Input.Commands;
using Code.Gameplay.Features.Input.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Input.Systems
{
  public class EmitInputSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<GameEntity> _inputs;

    public EmitInputSystem(GameContext game, IInputService inputService)
    {
      _inputService = inputService;
      _inputs = game.GetGroup(GameMatcher.Input);
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        foreach (InputCommand command in _inputService.GetInputCommands())
          command.ReassignCommandToEntity(input);

        _inputService.ResetInputCommands();
      }
    }
  }
}
