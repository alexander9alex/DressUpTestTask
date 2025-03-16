using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Zones
{
  public class CanPlaceItemZone : MonoBehaviour
  {
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out IEntityView entityView))
        return;

      entityView.Entity.isInCanPlaceItemZone = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out IEntityView entityView))
        return;

      entityView.Entity.isInCanPlaceItemZone = false;
    }
  }
}
