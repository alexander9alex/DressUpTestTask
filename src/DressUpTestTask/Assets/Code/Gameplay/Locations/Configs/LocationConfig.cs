using Code.Gameplay.Locations.Data;
using UnityEngine;

namespace Code.Gameplay.Locations.Configs
{
  [CreateAssetMenu(menuName = "Static Data/Location Config", fileName = "LocationConfig", order = 0)]
  public class LocationConfig : ScriptableObject
  {
    public LocationId LocationId;
    public GameObject LocationPrefab;
  }
}