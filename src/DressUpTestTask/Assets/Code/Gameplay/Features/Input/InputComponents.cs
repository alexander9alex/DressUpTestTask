using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Input
{
  [Game] public class Input : IComponent { }
  [Game] public class InteractionStarted : IComponent { }
  [Game] public class InteractionEnded : IComponent { }
  [Game] public class MousePosition : IComponent { public Vector2 Value; }
  [Game] public class InteractionStartedMousePosition : IComponent { public Vector2 Value; }
}
