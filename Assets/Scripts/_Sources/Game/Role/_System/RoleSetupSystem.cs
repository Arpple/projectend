using UnityEngine;
using Entitas;
using System;

namespace Game
{
	public class RoleSetupSystem : IInitializeSystem
	{
		private GameContext _context;
		private RoleSetting.RolesCount _rolesCount;

		public RoleSetupSystem(Contexts contexts, RoleSetting.RolesCount rolesCount)
		{
			_context = contexts.game;
			_rolesCount = rolesCount;
		}

		public void Initialize()
		{
			var players = _context.GetEntities(GameMatcher.Player).Shuffle();

			int i = 0;
			Action<RoleObject> assignRole = (r) => { players[i].AddRole(r); i++; };

			_rolesCount.Origin.Loop(() => assignRole(new RoleOrigin(_context)));
			_rolesCount.Invader.Loop(() => assignRole(new RoleInvader(_context)));
			_rolesCount.Seed.Loop(() => assignRole(new RoleSeed(_context)));
			_rolesCount.End.Loop(() => assignRole(new RoleEnd(_context)));
		}
	}

}
