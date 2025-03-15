using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Locations.Configs;
using Code.Gameplay.Locations.Data;
using UnityEngine;

namespace Code.Gameplay.Common
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<LocationId,LocationConfig> _locationById;

    public void LoadAll() =>
      LoadLocations();

    public GameObject GetLocationPrefab(LocationId locationId) =>
      _locationById[locationId].LocationPrefab;

    private void LoadLocations()
    {
      _locationById = Resources
        .LoadAll<LocationConfig>("Configs/Locations")
        .ToDictionary(x => x.LocationId, x => x);
    }
  }
}
