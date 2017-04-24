using System.Collections.Generic;
using Entitas;
using Network;
using UnityEngine;

public class PlayerCreatingSystem : IInitializeSystem, ITearDownSystem
{
	readonly GameContext _context;
	readonly List<Player> _players;

	public PlayerCreatingSystem(Contexts contexts, List<Player> players)
	{
		_context = contexts.game;
		_players = players;
	}

	public void Initialize()
	{
		foreach (var p in _players)
		{
			var entity = CreatePlayerEntity(p);
			LinkPlayerObject(entity, p.gameObject);
		}
	}

	private GameEntity CreatePlayerEntity(Player player)
	{
		var entity = _context.CreateEntity();
		entity.AddPlayer(player);
		entity.AddId(player.PlayerId);
		return entity;
	}

	private void LinkPlayerObject(GameEntity entity, GameObject obj)
	{
	}

	public void TearDown()
	{
	}
}
