//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInitializePosition;

    public static Entitas.IMatcher<GameEntity> InitializePosition {
        get {
            if (_matcherInitializePosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InitializePosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInitializePosition = matcher;
            }

            return _matcherInitializePosition;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Common.InitializePosition initializePositionComponent = new Code.Common.InitializePosition();

    public bool isInitializePosition {
        get { return HasComponent(GameComponentsLookup.InitializePosition); }
        set {
            if (value != isInitializePosition) {
                var index = GameComponentsLookup.InitializePosition;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : initializePositionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
