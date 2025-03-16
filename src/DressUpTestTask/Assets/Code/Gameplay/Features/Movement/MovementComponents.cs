using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
  [Game] public class PositionBeforeSelecting : IComponent { public Vector3 Value; }
  [Game] public class Falling : IComponent { }
  [Game] public class OnTheFloor : IComponent { }
  [Game] public class InCanLocateZone : IComponent { }
  [Game] public class InCantLocateZone : IComponent { }
}
