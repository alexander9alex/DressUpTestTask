using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Zones
{
  public class CantLocateZone : MonoBehaviour
  {
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out IEntityView entityView))
        return;

      entityView.Entity.isInCantLocateZone = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out IEntityView entityView))
        return;

      entityView.Entity.isInCantLocateZone = false;
    }
  }
}
