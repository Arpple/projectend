using System;
using System.Collections.Generic;
using Entitas;

public class DamageReductionSystem: ReactiveSystem<UnitEntity> {

    public DamageReductionSystem(Contexts context) : base(context.unit) {

    }

    protected override void Execute(List<UnitEntity> entities) {
        throw new NotImplementedException();
    }

    protected override bool Filter(UnitEntity entity) {
        throw new NotImplementedException();
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        //return context.CreateCollector<UnitEntity>(UnitMatcher.);
        throw new NotImplementedException();
    }
}
