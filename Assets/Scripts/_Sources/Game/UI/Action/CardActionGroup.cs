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
				var caster = Contexts.sharedInstance.game.LocalPlayerCharacter;
				var caller = new CardAbilityCaller(caster, cardEntity);

				if (!caller.TryUseAbility<GameEntity>(
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

		internal class CardAbilityCaller
		{
			private GameEntity _caster;
			private CardEntity _card;
			private Ability _ability;
			public UnityAction CancelAction;

			public CardAbilityCaller(GameEntity caster, CardEntity card)
			{
				_caster = caster;
				_card = card;
				_ability = _card.gameAbility.Ability;
			}

			public bool TryUseAbility<TTarget>(UnityAction<TTarget> onComplete) where TTarget : Entity
			{
				var ability = _ability as ActiveAbility<TTarget>;
				if(ability != null)
				{
					ShowAbility<TTarget>(ability, onComplete);
					return true;
				}

				return false;
			}

			private void ShowAbility<T>(ActiveAbility<T> ability, UnityAction<T> onComplete) where T : Entity
			{
				var selector = new TileTargetSelector<T>(
					_caster,
					ability.GetTilesArea(_caster),
					ability.GetTargetFromSelectedTile,
					(t) => onComplete(t)
				);
				CancelAction = selector.ClearSelection;
			}

		}
	}
}
