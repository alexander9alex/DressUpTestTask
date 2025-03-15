using Code.Common.Entities;
using Code.Common.Extensions;
using Code.Gameplay.Common;
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

      CreateEntity.Empty()
        .AddViewPrefab(locationPrefab)
        .AddWorldPosition(Vector3.zero)
        .With(x => x.isInitializePosition = true);
    }
  }
}
