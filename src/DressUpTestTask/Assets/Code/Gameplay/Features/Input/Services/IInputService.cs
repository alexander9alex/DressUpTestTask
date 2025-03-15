using System.Collections.Generic;
using Code.Gameplay.Features.Input.Commands;
using UnityEngine;

namespace Code.Gameplay.Features.Input.Services
{
  public interface IInputService
  {
    List<InputCommand> GetInputCommands();
    void ResetInputCommands();
    Vector2 GetMousePosition();
  }
}
