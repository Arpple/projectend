using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

namespace End.Game
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
			var players = _context.GetEntities(GameMatcher.Player);

			int i = 0;
			Action<Role> assignRole = (r) => { players[i].AddRole(r); i++; };

			_rolesCount.Origin.Loop(() => assignRole(new RoleOrigin(_context)));
			_rolesCount.Invader.Loop(() => assignRole(new RoleInvader(_context)));
		}
	}

}
