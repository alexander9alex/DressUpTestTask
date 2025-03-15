namespace Code.Gameplay.Features.Input.Commands
{
  public abstract class InputCommand
  {
    public abstract GameEntity ReassignCommandToEntity(GameEntity entity);
  }
}
