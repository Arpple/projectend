//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if(_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public CardContext card { get; set; }
    public GameContext game { get; set; }
    public GameEventContext gameEvent { get; set; }
    public TileContext tile { get; set; }
    public UnitContext unit { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { card, game, gameEvent, tile, unit }; } }

    public Contexts() {
        card = new CardContext();
        game = new GameContext();
        gameEvent = new GameEventContext();
        tile = new TileContext();
        unit = new UnitContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGenerator.Api.PostConstructorAttribute))
        );

        foreach(var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string GameId = "GameId";
    public const string GameMapPosition = "GameMapPosition";

    [Entitas.CodeGenerator.Api.PostConstructor]
    public void InitializeEntityIndices() {
        tile.AddEntityIndex(new Entitas.EntityIndex<TileEntity, int>(
            GameId,
            tile.GetGroup(TileMatcher.GameId),
            (e, c) => ((Game.IdComponent)c).Id));
        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            GameId,
            game.GetGroup(GameMatcher.GameId),
            (e, c) => ((Game.IdComponent)c).Id));
        unit.AddEntityIndex(new Entitas.EntityIndex<UnitEntity, int>(
            GameId,
            unit.GetGroup(UnitMatcher.GameId),
            (e, c) => ((Game.IdComponent)c).Id));
        card.AddEntityIndex(new Entitas.EntityIndex<CardEntity, int>(
            GameId,
            card.GetGroup(CardMatcher.GameId),
            (e, c) => ((Game.IdComponent)c).Id));

        tile.AddEntityIndex(new Entitas.EntityIndex<TileEntity, Position>(
            GameMapPosition,
            tile.GetGroup(TileMatcher.GameMapPosition),
            (e, c) => ((Game.MapPositionComponent)c).Value));
        unit.AddEntityIndex(new Entitas.EntityIndex<UnitEntity, Position>(
            GameMapPosition,
            unit.GetGroup(UnitMatcher.GameMapPosition),
            (e, c) => ((Game.MapPositionComponent)c).Value));
    }
}

public static class ContextsExtensions {

    public static System.Collections.Generic.HashSet<TileEntity> GetEntitiesWithGameId(this TileContext context, int Id) {
        return ((Entitas.EntityIndex<TileEntity, int>)context.GetEntityIndex(Contexts.GameId)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithGameId(this GameContext context, int Id) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.GameId)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<UnitEntity> GetEntitiesWithGameId(this UnitContext context, int Id) {
        return ((Entitas.EntityIndex<UnitEntity, int>)context.GetEntityIndex(Contexts.GameId)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<CardEntity> GetEntitiesWithGameId(this CardContext context, int Id) {
        return ((Entitas.EntityIndex<CardEntity, int>)context.GetEntityIndex(Contexts.GameId)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<TileEntity> GetEntitiesWithGameMapPosition(this TileContext context, Position Value) {
        return ((Entitas.EntityIndex<TileEntity, Position>)context.GetEntityIndex(Contexts.GameMapPosition)).GetEntities(Value);
    }

    public static System.Collections.Generic.HashSet<UnitEntity> GetEntitiesWithGameMapPosition(this UnitContext context, Position Value) {
        return ((Entitas.EntityIndex<UnitEntity, Position>)context.GetEntityIndex(Contexts.GameMapPosition)).GetEntities(Value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Unity.VisualDebugging.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public void CreateContextObserver(Entitas.IContext context) {
#if(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
        if(UnityEngine.Application.isPlaying) {
            var observer = new Entitas.Unity.VisualDebugging.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
#endif
    }

    [Entitas.CodeGenerator.Api.PostConstructor]
    public void InitializeContexObservers() {
        CreateContextObserver(card);
        CreateContextObserver(game);
        CreateContextObserver(gameEvent);
        CreateContextObserver(tile);
        CreateContextObserver(unit);
    }
}
