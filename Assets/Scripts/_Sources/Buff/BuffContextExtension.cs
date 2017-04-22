public static class BuffContextExtension 
{
	public static BuffEntity CreateBuff(this BuffContext context, Buff type)
	{
		var entity = context.CreateEntity();
		entity.AddBuff(type);
		return entity;
	}
}