using Lounge;
using UI;

using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance;

	[Header("Action")]
	public MainActionGroup MainGroup;
	[Space]
	public DeckCardActionGroup DeckGroup;
	[Space]
	public BoxCardActionGroup BoxGroup;
	[Space]
	public SkillCardActionGroup SkillGroup;
	[Space]
	public CancelActionGroup CancelGroup;
	[Space]
	public CardDiscardGroup DiscardGroup;

	[Header("Components")]
	public CardDescription CardDesc;
	public PlayerUnitStatusPanel LocalPlayerStatus;
	public WeatherStatusPanel WeatherStatus;
	public PlayerUnitStatusPanel TargetPlayerStatus;
	public TurnPanel TurnPanel;
    public MissionBookController MissionBookController;
    public Camera Camera;

	[Header("Notification")]
	public TurnNotification TurnNoti;

	[Header("Factory")]
	public PlayerDeckFactory DeckFactory;
	public PlayerBoxFactory BoxFactory;
	public PlayerSkillFactory SkillFactory;

	private CardObject _activeCard;
	private Setting _setting;

	[Inject]
	public void Construct(Setting setting)
	{
		_setting = setting;
	}

	private void Awake()
	{
		Instance = this;

		Assert.IsNotNull(MainGroup);
		Assert.IsNotNull(DeckGroup);
		Assert.IsNotNull(BoxGroup);
		Assert.IsNotNull(SkillGroup);
		Assert.IsNotNull(CancelGroup);
		Assert.IsNotNull(CardDesc);
		Assert.IsNotNull(DeckFactory);
		Assert.IsNotNull(BoxFactory);
		Assert.IsNotNull(LocalPlayerStatus);
		Assert.IsNotNull(WeatherStatus);
		Assert.IsNotNull(TargetPlayerStatus);
		Assert.IsNotNull(TurnPanel);
		Assert.IsNotNull(TurnNoti);
        Assert.IsNotNull(Camera);

		_currentGroup = MainGroup;
	}

	private void Start()
	{
		MainGroup.Init(_setting);
		CardDesc.Init();
		DeckFactory.Init();
		BoxFactory.Init();
		SkillFactory.Init();

        this.MissionBookController.LoadData(_setting.MissionSetting);
        Camera.backgroundColor = Color.black;
    }

    private ActionGroup _currentGroup;

	public void OnCardClicked(CardObject card)
	{
		var cardGroup = _currentGroup as CardActionGroup;
		if(cardGroup != null)
		{
			cardGroup.OnCardClick(card);
		}
	}

	public void SetCurrentGroup(ActionGroup group)
	{
		_currentGroup = group;
	}
}