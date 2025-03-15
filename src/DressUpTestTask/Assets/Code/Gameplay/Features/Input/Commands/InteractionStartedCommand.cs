using Code.Common.Extensions;

namespace Code.Gameplay.Features.Input.Commands
{
  class InteractionStartedCommand : InputCommand
  {
    public override GameEntity ReassignCommandToEntity(GameEntity entity) =>
      entity.With(x => x.isInteractionStarted = true);
  }
}
