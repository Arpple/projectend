public class PlayerSkillFactory : CardContainerFactory<CardContainer>
{
	public CardContainer CreateContainer(int playerId)
	{
		return base.CreateContainer("Skills", playerId);
	}
}