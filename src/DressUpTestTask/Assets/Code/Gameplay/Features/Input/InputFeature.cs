using Code.Gameplay.Features.Input.Systems;
using Code.Infrastructure.Factory;

namespace Code.Gameplay.Features.Input
{
  public sealed class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      
      Add(systems.Create<UpdateMousePositionSystem>());
      Add(systems.Create<EmitInputSystem>());
      Add(systems.Create<SetInteractionStartedMousePositionSystem>());
      
      Add(systems.Create<CleanupInteractionStartedSystem>());
      Add(systems.Create<CleanupInteractionStartedMousePositionSystem>());
      Add(systems.Create<CleanupInteractionEndedSystem>());
    }
  }
}