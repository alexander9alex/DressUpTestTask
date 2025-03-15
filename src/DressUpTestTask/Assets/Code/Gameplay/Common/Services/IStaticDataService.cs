using Code.Gameplay.Locations.Data;
using Code.Infrastructure.Views;

namespace Code.Gameplay.Common
{
  public interface IStaticDataService
  {
    void LoadAll();
    EntityBehaviour GetLocationPrefab(LocationId locationId);
  }
}
