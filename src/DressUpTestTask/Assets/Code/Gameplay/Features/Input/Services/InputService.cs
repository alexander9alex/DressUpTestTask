using System.Collections.Generic;
using Code.Gameplay.Features.Input.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Gameplay.Features.Input.Services
{
  class InputService : IInputService
  {
    private readonly GameInput _gameInput;
    private readonly List<InputCommand> _inputCommands = new();

    private Vector2 _mousePos;

    public InputService(GameInput gameInput)
    {
      _gameInput = gameInput;

      InitGameInput();
      _gameInput.Enable();
    }

    public List<InputCommand> GetInputCommands() =>
      _inputCommands;

    public void ResetInputCommands() =>
      _inputCommands.Clear();

    public Vector2 GetMousePosition() =>
      _mousePos;

    private void InitGameInput()
    {
      _gameInput.Game.MousePosition.performed += ChangeMousePosition;

      _gameInput.Game.Interaction.started += InteractionStarted;
      _gameInput.Game.Interaction.canceled += InteractionEnded;

      _gameInput.Game.Enable();
    }

    private void ChangeMousePosition(InputAction.CallbackContext context) =>
      _mousePos = context.ReadValue<Vector2>();

    private void InteractionStarted(InputAction.CallbackContext context) =>
      _inputCommands.Add(new InteractionStartedCommand());

    private void InteractionEnded(InputAction.CallbackContext context) =>
      _inputCommands.Add(new InteractionEndedCommand());
  }
}
