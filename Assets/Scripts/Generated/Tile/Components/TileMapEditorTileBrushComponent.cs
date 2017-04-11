//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TileContext {

    public TileEntity mapEditorTileBrushEntity { get { return GetGroup(TileMatcher.MapEditorTileBrush).GetSingleEntity(); } }
    public MapEditor.TileBrushComponent mapEditorTileBrush { get { return mapEditorTileBrushEntity.mapEditorTileBrush; } }
    public bool hasMapEditorTileBrush { get { return mapEditorTileBrushEntity != null; } }

    public TileEntity SetMapEditorTileBrush(Tile newTileType, MapEditor.BrushAction newAction, int newSpawnpointIndex) {
        if(hasMapEditorTileBrush) {
            throw new Entitas.EntitasException("Could not set MapEditorTileBrush!\n" + this + " already has an entity with MapEditor.TileBrushComponent!",
                "You should check if the context already has a mapEditorTileBrushEntity before setting it or use context.ReplaceMapEditorTileBrush().");
        }
        var entity = CreateEntity();
        entity.AddMapEditorTileBrush(newTileType, newAction, newSpawnpointIndex);
        return entity;
    }

    public void ReplaceMapEditorTileBrush(Tile newTileType, MapEditor.BrushAction newAction, int newSpawnpointIndex) {
        var entity = mapEditorTileBrushEntity;
        if(entity == null) {
            entity = SetMapEditorTileBrush(newTileType, newAction, newSpawnpointIndex);
        } else {
            entity.ReplaceMapEditorTileBrush(newTileType, newAction, newSpawnpointIndex);
        }
    }

    public void RemoveMapEditorTileBrush() {
        DestroyEntity(mapEditorTileBrushEntity);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TileEntity {

    public MapEditor.TileBrushComponent mapEditorTileBrush { get { return (MapEditor.TileBrushComponent)GetComponent(TileComponentsLookup.MapEditorTileBrush); } }
    public bool hasMapEditorTileBrush { get { return HasComponent(TileComponentsLookup.MapEditorTileBrush); } }

    public void AddMapEditorTileBrush(Tile newTileType, MapEditor.BrushAction newAction, int newSpawnpointIndex) {
        var index = TileComponentsLookup.MapEditorTileBrush;
        var component = CreateComponent<MapEditor.TileBrushComponent>(index);
        component.TileType = newTileType;
        component.Action = newAction;
        component.SpawnpointIndex = newSpawnpointIndex;
        AddComponent(index, component);
    }

    public void ReplaceMapEditorTileBrush(Tile newTileType, MapEditor.BrushAction newAction, int newSpawnpointIndex) {
        var index = TileComponentsLookup.MapEditorTileBrush;
        var component = CreateComponent<MapEditor.TileBrushComponent>(index);
        component.TileType = newTileType;
        component.Action = newAction;
        component.SpawnpointIndex = newSpawnpointIndex;
        ReplaceComponent(index, component);
    }

    public void RemoveMapEditorTileBrush() {
        RemoveComponent(TileComponentsLookup.MapEditorTileBrush);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TileMatcher {

    static Entitas.IMatcher<TileEntity> _matcherMapEditorTileBrush;

    public static Entitas.IMatcher<TileEntity> MapEditorTileBrush {
        get {
            if(_matcherMapEditorTileBrush == null) {
                var matcher = (Entitas.Matcher<TileEntity>)Entitas.Matcher<TileEntity>.AllOf(TileComponentsLookup.MapEditorTileBrush);
                matcher.componentNames = TileComponentsLookup.componentNames;
                _matcherMapEditorTileBrush = matcher;
            }

            return _matcherMapEditorTileBrush;
        }
    }
}
