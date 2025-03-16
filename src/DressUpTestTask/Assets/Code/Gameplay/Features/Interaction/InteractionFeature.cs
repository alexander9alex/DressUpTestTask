using Code.Gameplay.Features.Interaction.Systems;
using Code.Infrastructure.Factory;

namespace Code.Gameplay.Features.Interaction
{
  public sealed class InteractionFeature : Feature
  {
    public InteractionFeature(ISystemFactory systems)
    {
      Add(systems.Create<MarkSelectedNearestItemSystem>());
      
      Add(systems.Create<ContinueFallingSystem>());
      Add(systems.Create<UnselectSelectedItemsSystem>());
    }
  }
}
