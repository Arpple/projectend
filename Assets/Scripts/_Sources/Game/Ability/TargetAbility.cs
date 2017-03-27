using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace End.Game
{
	public abstract class TargetAbility : Ability, ITargetAbility
	{
		protected virtual int _range{ get { return 1; } }

		private GameEntity[] _showingArea;
		private GameEntity _caster;
		private Action _callback;

		/// <summary>
		/// Activates the ability.
		/// </summary>
		/// <param name="caster">The caster.</param>
		public override void ActivateAbility(GameEntity caster, Action callback)
		{
			Assert.IsTrue(caster.hasMapPosition);
			_caster = caster;
			_callback = callback;
			ShowTarget();
		}

		/// <summary>
		/// Shows the area is in range.
		/// </summary>
		/// <param name="position">The position in area.</param>
		public void ShowAreaOnPosition(GameEntity position)
		{
			position.view.GameObject.GetComponent<TileController>().Span.enabled = true;
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
				e.view.GameObject.GetComponent<TileController>().Span.enabled = false;

				if (e.hasTileAction)
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
			_showingArea = GetTileEntityInArea(_caster);
			foreach (var targetPosition in _showingArea)
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
			_callback();
		}
	}
}
