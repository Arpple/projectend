using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CardDescription : MonoBehaviour
{
	private enum State
	{
		Active,
		Passive,
	}

	public Text CardName;
	public Text CardDetail;

	[Header("Animator")]
	public Animator Animator;

	[Header("Button Panel")]
	public Animator ButtonGroup_Animator;
	public GameObject ButtonGroup;
	public Button ActiveButton;
	public Button PassiveButton;

	private State _state;
	private CardDescriptionComponent _description;

	public void Init()
	{
		Assert.IsNotNull(CardName);
		Assert.IsNotNull(CardDetail);
		ShowActiveDescription();
		_state = State.Active;
	}

	public void SetDescription(CardObject card)
	{
		_description = card.Entity.cardDescription;
		UpdateDescription();
	}

	private void UpdateDescription()
	{
		CardName.text = _description.Name;
		CardDetail.text = _state == State.Active
			? _description.ActiveDesc
			: _description.PassiveDesc;
	}

	private void PlayStateSwapAnimation()
	{
		Animator.Play("SwapDescription");
	}

	public void ToggleVisibility()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}
	public void ReButtonOrder(string buttonName) {
		Transform b = ButtonGroup.transform.FindChild(buttonName);
		if(b != null) {
			b.transform.SetAsLastSibling();
		}
	}

	public void ShowActiveDescription() {
		if (_state == State.Active) return;

		_state = State.Active;

		ReButtonOrder(ActiveButton.name);
		ButtonGroup_Animator.Play("FocusActive");
		Animator.Play("SwapDescription");
		UpdateDescription();
	}

	public void ShowPassiveDescription() {
		if (_state == State.Passive) return;

		_state = State.Passive;

		ReButtonOrder(PassiveButton.name);
		ButtonGroup_Animator.Play("FocusPassive");
		Animator.Play("SwapDescription");
		UpdateDescription();
	}

	public void ReorderButtonToTop(Button button) {
		button.transform.SetAsLastSibling();
	}
}