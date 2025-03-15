using Code.Gameplay.Features.Input.Services;
using Entitas;

namespace Code.Gameplay.Features.Input
{
  public class StartInputSystem : IInitializeSystem
  {
    private readonly IInputService _inputService;

    public StartInputSystem(IInputService inputService) =>
      _inputService = inputService;

    public void Initialize() =>
      _inputService.StartInput();
  }
}
