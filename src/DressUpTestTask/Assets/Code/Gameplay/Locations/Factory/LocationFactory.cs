using Code.Common.Entities;
using Code.Common.Extensions;
using Code.Gameplay.Common.Services;
using Code.Gameplay.Items.Markers;
using Code.Gameplay.Locations.Data;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Locations.Factory
{
  class LocationFactory : ILocationFactory
  {
    private readonly IStaticDataService _staticData;

    public LocationFactory(IStaticDataService staticData) =>
      _staticData = staticData;

    public void CreateLocation(LocationId locationId)
    {
      EntityBehaviour locationPrefab = _staticData.GetLocationPrefab(locationId);

      CreateLocation(locationPrefab);
      CreateItems(locationPrefab);
    }

    private static void CreateLocation(EntityBehaviour locationPrefab)
    {
      CreateEntity.Empty()
        .AddViewPrefab(locationPrefab)
        .AddWorldPosition(Vector3.zero)
        .With(x => x.isInitializePosition = true);
    }

    private void CreateItems(EntityBehaviour prefab)
    {
      foreach (CreateItemMarker marker in prefab.GetComponentsInChildren<CreateItemMarker>())
      {
        CreateEntity.Empty()
          .AddViewPrefab(_staticData.GetItemPrefab(marker.ItemId))
          .AddWorldPosition(marker.transform.position)
          .With(x => x.isInitializePosition = true)
          ;
      }
    }
  }
}
