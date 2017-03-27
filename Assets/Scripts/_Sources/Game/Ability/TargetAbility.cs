using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace End.Game
{
	public abstract class TargetAbility : Ability, ITargetAbility
	{
		protected virtual int _range{ get { return 1; } }

		private readonly List<GameEntity> _showingArea;
		private GameEntity _caster;

		public TargetAbility()
		{
			_showingArea = new List<GameEntity>();
		}

		/// <summary>
		/// Activates the ability.
		/// </summary>
		/// <param name="caster">The caster.</param>
		public override void ActivateAbility(GameEntity caster)
		{
			Assert.IsTrue(caster.hasMapPosition);
			_caster = caster;
			ShowTarget();
		}

		/// <summary>
		/// Shows the area is in range.
		/// </summary>
		/// <param name="position">The position in area.</param>
		public void ShowAreaOnPosition(GameEntity position)
		{
			//TODO: highlight 
		}

		/// <summary>
		/// Called when canceled
		/// </summary>
		public void OnTargetCancel()
		{
			ClearArea();
		}

		/// <summary>
		/// Clears the area action.
		/// </summary>
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

		public abstract GameEntity[] GetTileEntityInArea(GameEntity caster);

		/// <summary>
		/// Gets the target from position.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <returns>null if target not found otherwise return the target entity</returns>
		public abstract GameEntity GetTarget(GameEntity position);

		public abstract void ApplyAbilityEffect(GameEntity caster, GameEntity target);

		public void ShowTarget()
		{
			var inAreaTargets = GetTileEntityInArea(_caster);
			foreach (var targetPosition in inAreaTargets)
			{
				ShowAreaOnPosition(targetPosition);
				var target = GetTarget(targetPosition);
				if (target != null)
				{
					targetPosition.AddTileAction(() => OnTargetSelected((targetPosition)));
				}
			}
		}

		public void OnTargetSelected(GameEntity target)
		{
			ApplyAbilityEffect(_caster, target);
			ClearArea();
		}
	}
}
