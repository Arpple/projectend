public partial class CharacterEntityFactory : UnitEntityFactory
{
	protected class CharacterComponentFactory : UnitComponentFactory
	{
		protected CharacterData _characterData;

		public CharacterComponentFactory(UnitEntity entity, CharacterData data) : base(entity, data)
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