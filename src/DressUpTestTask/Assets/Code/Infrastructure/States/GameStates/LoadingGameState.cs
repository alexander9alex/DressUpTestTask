using Code.Gameplay.Locations.Data;
using Code.Gameplay.Locations.Factory;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Views.Factory;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadingGameState : SimpleState
  {
    private const string GameScene = "Game";

    private readonly IGameStateMachine _gameStateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly ILocationFactory _locationFactory;
    private readonly IEntityViewFactory _entityViewFactory;

    public LoadingGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILocationFactory locationFactory,
      IEntityViewFactory entityViewFactory)
    {
      _gameStateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _locationFactory = locationFactory;
      _entityViewFactory = entityViewFactory;
    }

    public override void Enter() =>
      _sceneLoader.LoadScene(GameScene, OnLoaded);

    private void OnLoaded()
    {
      _entityViewFactory.SetEntityViewParent(CreateEntityParent());

      _locationFactory.CreateLocation(LocationId.Room);

      _gameStateMachine.Enter<GameLoopState>();
    }

    private static Transform CreateEntityParent() =>
      new GameObject("EntityParent").transform;
  }
}
