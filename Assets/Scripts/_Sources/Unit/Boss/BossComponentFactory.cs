public partial class BossEntityFactory : UnitEntityFactory
{
	protected class BossComponentFactory : UnitComponentFactory
	{
		protected BossData _characterData;

		public BossComponentFactory(UnitEntity entity, BossData data) : base(entity, data)
		{
			_characterData = data;
		}

		public override void AddComponents()
		{
			base.AddComponents();
			AddSkillsComponent();
		}

		private void AddSkillsComponent()
		{
			var skills = _characterData.SkillCards;
			if (skills != null && skills.Count > 0)
			{
				_entity.AddCharacterSkillsResource(_characterData.SkillCards);
			}
		}
	}
}