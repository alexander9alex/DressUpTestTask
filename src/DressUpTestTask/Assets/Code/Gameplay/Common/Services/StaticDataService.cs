using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Items.Configs;
using Code.Gameplay.Items.Data;
using Code.Gameplay.Locations.Configs;
using Code.Gameplay.Locations.Data;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Common.Services
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<LocationId, LocationConfig> _locationConfigById;
    private Dictionary<ItemId, ItemConfig> _itemConfigById;

    public void LoadAll()
    {
      LoadLocationConfigs();
      LoadItemConfigs();
    }

    public EntityBehaviour GetLocationPrefab(LocationId locationId) =>
      _locationConfigById[locationId].LocationPrefab;

    public EntityBehaviour GetItemPrefab(ItemId itemId) =>
      _itemConfigById[itemId].ItemPrefab;

    private void LoadLocationConfigs()
    {
      _locationConfigById = Resources
        .LoadAll<LocationConfig>("Configs/Locations")
        .ToDictionary(x => x.LocationId, x => x);
    }

    private void LoadItemConfigs()
    {
      _itemConfigById = Resources
        .LoadAll<ItemConfig>("Configs/Items")
        .ToDictionary(x => x.ItemId, x => x);
    }
  }
}
