using Code.Gameplay.Items.Data;
using Code.Gameplay.Locations.Data;
using Code.Infrastructure.Views;

namespace Code.Gameplay.Common.Services
{
  public interface IStaticDataService
  {
    void LoadAll();
    EntityBehaviour GetLocationPrefab(LocationId locationId);
    EntityBehaviour GetItemPrefab(ItemId itemId);
  }
}
