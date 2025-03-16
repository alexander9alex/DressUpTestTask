using Code.Common.Extensions;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Zones
{
  public class FloorZone : MonoBehaviour
  {
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out IEntityView entityView))
        return;

      entityView.Entity.With(x => x.isFalling = false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (!other.gameObject.TryGetComponent(out IEntityView entityView))
        return;

      entityView.Entity.With(x => x.isFalling = true);
    }
  }
}
