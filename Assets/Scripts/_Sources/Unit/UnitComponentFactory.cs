public partial class UnitEntityFactory : EntityFactory<UnitEntity, UnitData>
{
	protected class UnitComponentFactory : ComponentFactory<UnitEntity, UnitData>
	{
		public UnitComponentFactory(UnitEntity entity, UnitData data) : base(entity, data)
		{
		}

		public override void AddComponents()
		{
			AddBodySprite();
			AddIconSprite();
			AddUnitDetail();
			AddUnitStatus();
		}

		protected void AddBodySprite()
		{
			if(_data.BodySprite != null)
			{
				_entity.AddSprite(_data.BodySprite);
			}
		}

		protected void AddIconSprite()
		{
			if(_data.IconSprite != null)
			{
				_entity.AddUnitIcon(_data.IconSprite);
			}
		}

		protected void AddUnitDetail()
		{
			_entity.AddUnitDetail(_data.Name, _data.Description);
		}

		protected void AddUnitStatus()
		{
			_entity.AddUnitStatus(
				_data.HitPoint,
				_data.AttackPower,
				_data.AttackRange,
				_data.VisionRange,
				_data.MoveSpeed
			);

			_entity.AddHitpoint(_data.HitPoint);
		}
	}
}
