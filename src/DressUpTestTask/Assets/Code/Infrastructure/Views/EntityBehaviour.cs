using UnityEngine;

namespace Code.Infrastructure.Views
{
  public class EntityBehaviour : MonoBehaviour, IEntityView
  {
    public GameEntity Entity => _entity;
    private GameEntity _entity;
    
    public void SetEntity(GameEntity entity)
    {
      _entity = entity;
      _entity.AddView(this);
      _entity.Retain(this);
    }

    public void ReleaseEntity()
    {
      _entity.Release(this);
      _entity = null;
    }
  }
}
