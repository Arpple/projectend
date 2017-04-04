using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	public abstract class CardActionGroup : ActionGroup
	{
		public abstract void SetAction(CardObject card);

		public void ShowCardTarget(CardObject card)
		{
			if (!Contexts.sharedInstance.game.IsLocalPlayerTurn) return;

			var cardEntity = card.Entity;

			if (cardEntity.hasAbility)
			{
				var ability = cardEntity.ability.Ability as IActiveAbility;
				if (ability == null) return;

				var caster = Contexts.sharedInstance.game.LocalPlayerCharacter;

				TileTargetSelector tileSelector = new TileTargetSelector(
					caster,
					ability.GetTilesArea(caster),
					ability.GetTargetEntity,
					(t) =>
					{
						if (t.hasUnit)
						{
							EventUseCardOnUnit.Create(caster, cardEntity, t);
						}
						else if (t.hasTile)
						{
							EventUseCardOnTile.Create(caster, cardEntity, t);
						}
						CloseAction();
					}
				);

				OnCloseHandler += tileSelector.ClearSelection;
			}
		}
	}
}
