using System.Collections.Generic;
using Entitas;

public class DefaultTileActionSetupSystem : ReactiveSystem<TileEntity>
{
	private PlayerUnitStatusPanel _panel;
	private CardContext _cardContext;

	public DefaultTileActionSetupSystem(Contexts contexts, PlayerUnitStatusPanel statusPanel) : base(contexts.tile)
	{
		_panel = statusPanel;
		_cardContext = contexts.card;
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.View);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasView;
	}


	protected override void Execute(List<TileEntity> entities)
	{
		foreach (var e in entities)
		{
			var tileCon = e.view.GameObject.GetComponent<TileController>();
			tileCon.DefaultTileAction = OnTileClicked;
		}
	}

	private void OnTileClicked(TileEntity tile)
	{
		var unit = tile.GetUnitOnTile();
		if (unit != null)
		{
			ShowDisplayStatus(unit);
		}
		else
		{
			HideDisplayStatus();
		}
	}

	private void ShowDisplayStatus(UnitEntity unit)
	{
		_panel.SetCharacter(unit);
		_panel.gameObject.SetActive(true);
		_panel.UpdateBoxCardCount(_cardContext.GetPlayerBoxCards(unit.owner.Entity).Length);
		_panel.UpdateDeckCardCount(_cardContext.GetPlayerDeckCards(unit.owner.Entity).Length);
	}

	private void HideDisplayStatus()
	{
		_panel.HideDisplay();
	}
}