using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderDeadSpriteSystem: ReactiveSystem<UnitEntity> {

    private Sprite _deadSprite;
    public RenderDeadSpriteSystem(Contexts contexts , UnitSetting unitSetting) : base(contexts.unit) {
        this._deadSprite = unitSetting.DeadSprite;
    }
    
    protected override bool Filter(UnitEntity entity) {
        return entity.isDead;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector<UnitEntity>(UnitMatcher.Dead, GroupEvent.Added);
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach(var unit in entities) {
            Debug.Log(unit.view.GameObject.name + " is dead ");
            unit.view.GameObject.GetComponent<SpriteRenderer>().sprite = this._deadSprite;
        }
    }
}
