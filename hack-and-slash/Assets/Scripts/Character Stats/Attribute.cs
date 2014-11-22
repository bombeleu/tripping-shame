public class Attribute : BaseStat
{
	public Attribute()
	{
		ExpToLevel = 50;
		LevelModifier = 1.05f;
	}
}

public enum AttributeNames
{
	Strength,
	Constitution,
	Dexterity,
	Speed,
	Concentration,
	Willpower,
	Charisma
}
