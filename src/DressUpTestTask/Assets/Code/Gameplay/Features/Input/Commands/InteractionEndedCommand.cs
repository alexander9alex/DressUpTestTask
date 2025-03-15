using Code.Common.Extensions;

namespace Code.Gameplay.Features.Input.Commands
{
  class InteractionEndedCommand : InputCommand
  {
    public override GameEntity ReassignCommandToEntity(GameEntity entity) =>
      entity.With(x => x.isInteractionEnded = true);
  }
}
