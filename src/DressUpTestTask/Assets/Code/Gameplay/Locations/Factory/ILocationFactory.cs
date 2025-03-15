using Code.Gameplay.Locations.Data;

namespace Code.Gameplay.Locations.Factory
{
  public interface ILocationFactory
  {
    void CreateLocation(LocationId locationId);
  }
}
