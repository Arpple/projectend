using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace MapEditor
{
	public class ToolKitsButtonSetupSystem : IInitializeSystem
	{
		private MapEditorToolkits _toolKits;
		private TileContext _context;

		public ToolKitsButtonSetupSystem(Contexts contexts, MapEditorToolkits toolKits)
		{
			_toolKits = toolKits;
			_context = contexts.tile;
		}

		public void Initialize()
		{
			foreach (Tile tile in Enum.GetValues(typeof(Tile)))
			{
				var button = _toolKits.CreateButton(tile);
				button.onClick.AddListener(() =>
				{
					ChangeTileBrush(tile);
					_toolKits.SetActiveTileBrushButton(button);
				});
			}
		}

		private void ChangeTileBrush(Tile type)
		{
			_context.mapEditorTileBrush.TileType = type;
		}
	}
}
