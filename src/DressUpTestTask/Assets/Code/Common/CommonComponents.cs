using Code.Infrastructure.Views;
using Entitas;
using EntityBehaviour = Entitas.VisualDebugging.Unity.EntityBehaviour;

namespace Code.Common
{
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
  [Game] public class View : IComponent { public IEntityView Value; }
  
}
