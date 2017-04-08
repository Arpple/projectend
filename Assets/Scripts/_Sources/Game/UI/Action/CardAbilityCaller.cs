using UnityEngine;
using UnityEngine.Events;
using Entitas;
using System.Collections;

namespace Game.UI
{
	public class CardAbilityCaller
	{
		private UnitEntity _caster;
		private CardEntity _card;
		private Ability _ability;
		public UnityAction CancelAction;

		public CardAbilityCaller(UnitEntity caster, CardEntity card)
		{
			_caster = caster;
			_card = card;
			_ability = _card.gameAbility.Ability;
		}

		public bool TryUseAbility<TTarget>(UnityAction<TTarget> onComplete) where TTarget : Entity
		{
			var ability = _ability as ActiveAbility<TTarget>;
			if (ability != null)
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
