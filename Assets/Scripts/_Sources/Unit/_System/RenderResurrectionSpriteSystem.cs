using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderResurrectionSpriteSystem: ReactiveSystem<UnitEntity> {
    
    public RenderResurrectionSpriteSystem(Contexts contexts) : base(contexts.unit) {

    }
    
    protected override bool Filter(UnitEntity entity) {
        return !entity.isDead;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector<UnitEntity>(UnitMatcher.Dead, GroupEvent.Removed);
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach(var unit in entities) {
            Debug.Log(unit.view.GameObject.name + " is Resurrection ");
            unit.view.GameObject.GetComponent<SpriteRenderer>().sprite = unit.sprite.Sprite;
        }
    }
}

