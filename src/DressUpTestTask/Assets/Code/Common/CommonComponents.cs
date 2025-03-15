using Code.Infrastructure.Views;
using Entitas;
using UnityEngine;

namespace Code.Common
{
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class Destructed : IComponent { }
  [Game] public class TransformComponent : IComponent { public Transform Value; }
  [Game] public class WorldPosition : IComponent { public Vector3 Value; }
  [Game] public class InitializePosition : IComponent { }
}
