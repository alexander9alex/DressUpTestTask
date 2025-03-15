﻿using Code.Gameplay.Features.Destruct;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Views;

namespace Code.Gameplay.Features
{
  public sealed class GameplayFeature : Feature
  {
    public GameplayFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindViewFeature>());
      
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}
