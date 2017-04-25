using Entitas;
using UnityEngine.Events;

public class CardAbilityCaller
{
	private UnitEntity _caster;
	private CardEntity _card;
	private Ability _ability;
	private CardActionGroup _callerGroup;

	public UnityAction CancelAction;

	public CardAbilityCaller(CardActionGroup callerActionGroup, UnitEntity caster, CardEntity card)
	{
		_caster = caster;
		_card = card;
		_ability = _card.ability.Ability;
		_callerGroup = callerActionGroup;
	}

	public bool TryUseAbility<TTarget>(UnityAction<TTarget> onComplete) where TTarget : Entity
	{
		var ability = _ability as ActiveAbility<TTarget>;
		if (ability != null)
		{
			ShowAbilityArea<TTarget>(ability, onComplete);
			return true;
		}

		return false;
	}

	private void ShowAbilityArea<T>(ActiveAbility<T> ability, UnityAction<T> onComplete) where T : Entity
	{
		var selector = new TileTargetSelector<T>(
			_caster,
			ability.GetTilesArea(_caster),
			ability.GetTargetFromSelectedTile,
			(t) =>
			{
				CheckCardCost(() =>
				{
					onComplete(t);
					_callerGroup.CloseAction();
				});
			}
		);
		CancelAction = selector.ClearSelection;
	}

	private void CheckCardCost(UnityAction onComplete)
	{
		var disAbility = _ability as IDiscardCardAbility;
		if (disAbility != null)
		{
			var disGroup = (CardDiscardGroup)_callerGroup.ShowSubAction(GameUI.Instance.DiscardGroup);
			disGroup.Setup(_callerGroup.CardPanel, disAbility.Count, onComplete, 
				string.Format("discard {0} card(s) to activate", disAbility.Count)
			);
		}
		else
		{
			onComplete();
		}
	}
}