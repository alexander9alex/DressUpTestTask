using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Zones
{
  public class FloorZone : MonoBehaviour
  {
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out LinkToEntityBehaviour linkToEntityBehaviour))
        return;

      linkToEntityBehaviour.EntityBehaviour.Entity.isOnTheFloor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out LinkToEntityBehaviour linkToEntityBehaviour))
        return;

      linkToEntityBehaviour.EntityBehaviour.Entity.isOnTheFloor = false;
    }
  }
}
