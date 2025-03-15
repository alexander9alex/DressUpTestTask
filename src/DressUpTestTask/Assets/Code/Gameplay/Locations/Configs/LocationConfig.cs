using Code.Gameplay.Locations.Data;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Locations.Configs
{
  [CreateAssetMenu(menuName = "Static Data/Location Config", fileName = "LocationConfig", order = 0)]
  public class LocationConfig : ScriptableObject
  {
    public LocationId LocationId;
    public EntityBehaviour LocationPrefab;
  }
}
