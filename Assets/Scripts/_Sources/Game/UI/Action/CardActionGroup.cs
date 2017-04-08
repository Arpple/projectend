using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using Entitas;

namespace Game.UI
{
	public abstract class CardActionGroup : ActionGroup
	{
		public abstract void SetAction(CardObject card);

		public void ShowCardTarget(CardObject card)
		{
			if (!Contexts.sharedInstance.game.IsLocalPlayerTurn) return;

			var cardEntity = card.Entity;

			if (cardEntity.hasGameAbility)
			{
				var caster = Contexts.sharedInstance.unit.gameLocalEntity;
				var caller = new CardAbilityCaller(caster, cardEntity);

				if (!caller.TryUseAbility<UnitEntity>(
					(t) =>
					{
						EventUseCardOnUnit.Create(caster, cardEntity, t);
						CloseAction();
					}
				))
				if (!caller.TryUseAbility<TileEntity>(
					(t) =>
					{
						EventUseCardOnTile.Create(caster, cardEntity, t);
						CloseAction();
					}
				))
				return;

				OnCloseHandler += caller.CancelAction;
			}
		}
	}
}
