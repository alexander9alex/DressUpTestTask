//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInteractionStartedMousePosition;

    public static Entitas.IMatcher<GameEntity> InteractionStartedMousePosition {
        get {
            if (_matcherInteractionStartedMousePosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InteractionStartedMousePosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInteractionStartedMousePosition = matcher;
            }

            return _matcherInteractionStartedMousePosition;
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

    public Code.Gameplay.Features.Input.InteractionStartedMousePosition interactionStartedMousePosition { get { return (Code.Gameplay.Features.Input.InteractionStartedMousePosition)GetComponent(GameComponentsLookup.InteractionStartedMousePosition); } }
    public UnityEngine.Vector2 InteractionStartedMousePosition { get { return interactionStartedMousePosition.Value; } }
    public bool hasInteractionStartedMousePosition { get { return HasComponent(GameComponentsLookup.InteractionStartedMousePosition); } }

    public GameEntity AddInteractionStartedMousePosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.InteractionStartedMousePosition;
        var component = (Code.Gameplay.Features.Input.InteractionStartedMousePosition)CreateComponent(index, typeof(Code.Gameplay.Features.Input.InteractionStartedMousePosition));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceInteractionStartedMousePosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.InteractionStartedMousePosition;
        var component = (Code.Gameplay.Features.Input.InteractionStartedMousePosition)CreateComponent(index, typeof(Code.Gameplay.Features.Input.InteractionStartedMousePosition));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveInteractionStartedMousePosition() {
        RemoveComponent(GameComponentsLookup.InteractionStartedMousePosition);
        return this;
    }
}
