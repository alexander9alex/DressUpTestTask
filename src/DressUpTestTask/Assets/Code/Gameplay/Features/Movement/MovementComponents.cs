using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
  [Game] public class PositionBeforeSelecting : IComponent { public Vector3 Value; }
  [Game] public class Falling : IComponent { }
}
