using System.Collections.Generic;
using UnityEngine.Assertions;

namespace End.Game
{
	public abstract class TargetAbility : Ability
	{
		private readonly IAreaSelector _selector;
		private readonly List<GameEntity> _showingArea;

		public TargetAbility(IAreaSelector selector)
		{
			_selector = selector;
			_showingArea = new List<GameEntity>();
		}

		public override void ActivateAbility(GameEntity caster)
		{
			Assert.IsTrue(caster.hasMapPosition);

			var inAreaTargets = _selector.GetEntityInArea(caster.mapPosition);
			foreach(var targetPosition in inAreaTargets)
			{
				ShowAreaOnPosition(targetPosition);
				var target = GetTarget(targetPosition);
				if(target != null)
				{
					targetPosition.AddTileAction(() => OnTargetSelected(caster, GetTarget(targetPosition)));
				}
			}
		}

		public void ShowAreaOnPosition(GameEntity position)
		{
			//TODO: highlight 
		}

		public void OnTargetCancel()
		{
			ClearArea();
		}

		public void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			ApplyAbilityEffect(caster, target);
			ClearArea();
		}

		public void ClearArea()
		{
			foreach(var e in _showingArea)
			{
				//TODO: unhightlight

				if(e.hasTileAction)
				{
					e.RemoveTileAction();
				}
			}
		}

		public abstract GameEntity GetTarget(GameEntity position);
		public abstract void ApplyAbilityEffect(GameEntity caster, GameEntity target);
	}
}
