using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

namespace Game.UI
{
	public class LocalCharacterStatusSystem : ReactiveSystem<UnitEntity>, IInitializeSystem
	{
		private readonly UnitContext _context;
		private readonly PlayerUnitStatusPanel _ui;

		public LocalCharacterStatusSystem(Contexts contexts, PlayerUnitStatusPanel ui) : base(contexts.unit)
		{
			_context = contexts.unit;
			_ui = ui;
		}

		public void Initialize()
		{
			_ui.SetCharacter(_context.GetEntities(UnitMatcher.GameCharacter)
				.Where(c => c.gameOwner.Entity.isGameLocalPlayer)
				.First());
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameUnitStatus, GroupEvent.Added);
		}

		protected override bool Filter(UnitEntity entity)
		{
			return entity.hasGameUnitStatus && entity.gameOwner.Entity.isGameLocalPlayer;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			foreach(var entity in entities)
			{
				_ui.UpdateUnitStatus(entity.gameUnitStatus);
			}
		}
	}

}
