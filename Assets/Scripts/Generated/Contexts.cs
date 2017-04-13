//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
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
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
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
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string Id = "Id";
    public const string MapPosition = "MapPosition";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        card.AddEntityIndex(new Entitas.EntityIndex<CardEntity, int>(
            Id,
            card.GetGroup(CardMatcher.Id),
            (e, c) => ((IdComponent)c).Id));
        tile.AddEntityIndex(new Entitas.EntityIndex<TileEntity, int>(
            Id,
            tile.GetGroup(TileMatcher.Id),
            (e, c) => ((IdComponent)c).Id));
        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            Id,
            game.GetGroup(GameMatcher.Id),
            (e, c) => ((IdComponent)c).Id));
        unit.AddEntityIndex(new Entitas.EntityIndex<UnitEntity, int>(
            Id,
            unit.GetGroup(UnitMatcher.Id),
            (e, c) => ((IdComponent)c).Id));

        unit.AddEntityIndex(new Entitas.EntityIndex<UnitEntity, Position>(
            MapPosition,
            unit.GetGroup(UnitMatcher.MapPosition),
            (e, c) => ((MapPositionComponent)c).Value));
        tile.AddEntityIndex(new Entitas.EntityIndex<TileEntity, Position>(
            MapPosition,
            tile.GetGroup(TileMatcher.MapPosition),
            (e, c) => ((MapPositionComponent)c).Value));
    }
}

public static class ContextsExtensions {

    public static System.Collections.Generic.HashSet<CardEntity> GetEntitiesWithId(this CardContext context, int Id) {
        return ((Entitas.EntityIndex<CardEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<TileEntity> GetEntitiesWithId(this TileContext context, int Id) {
        return ((Entitas.EntityIndex<TileEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithId(this GameContext context, int Id) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<UnitEntity> GetEntitiesWithId(this UnitContext context, int Id) {
        return ((Entitas.EntityIndex<UnitEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntities(Id);
    }

    public static System.Collections.Generic.HashSet<UnitEntity> GetEntitiesWithMapPosition(this UnitContext context, Position Value) {
        return ((Entitas.EntityIndex<UnitEntity, Position>)context.GetEntityIndex(Contexts.MapPosition)).GetEntities(Value);
    }

    public static System.Collections.Generic.HashSet<TileEntity> GetEntitiesWithMapPosition(this TileContext context, Position Value) {
        return ((Entitas.EntityIndex<TileEntity, Position>)context.GetEntityIndex(Contexts.MapPosition)).GetEntities(Value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if(!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContexObservers() {
        CreateContextObserver(card);
        CreateContextObserver(game);
        CreateContextObserver(gameEvent);
        CreateContextObserver(tile);
        CreateContextObserver(unit);
    }

    public void CreateContextObserver(Entitas.IContext context) {
        try {
            if(UnityEngine.Application.isPlaying) {
                var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
                UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
            }
        } catch(System.Exception) {
        }
    }

#endif
}
