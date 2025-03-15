using Code.Gameplay.Locations.Data;
using UnityEngine;

namespace Code.Gameplay.Common
{
  public interface IStaticDataService
  {
    void LoadAll();
    GameObject GetLocationPrefab(LocationId locationId);
  }
}
