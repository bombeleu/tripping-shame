public class BaseStat
{
	private int _baseValue;
	private int _buffValue;
	private int _expToLevel;
	private float _levelModifier;
	
	public BaseStat()
	{
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f;
		_expToLevel = 100;
	} 
	
	#region basic setters and getters
	//Basic Setters and Getters (What is this Madness?!?!)
	public int BaseValue
	{
		get{ return _baseValue; }
		set{ _baseValue = value; }
	}
	
	public int BuffValue
	{
		get{ return _buffValue; }
		set{ _buffValue = value; }
	}
	
	public int ExpToLevel
	{
		get{ return _expToLevel; }
		set{ _expToLevel = value; }
	}
	
	public float LevelModifier
	{
		get{ return _levelModifier; }
		set{ _levelModifier = value; }
	}
	#endregion
	
	public void LevelUp()
	{
		_expToLevel = CalculateExpToLevel();
		++_baseValue;
	}
	
	public int AdjustedBaseValue()
	{
		return _baseValue + _buffValue;
	}
	
	private int CalculateExpToLevel()
	{
		return (int)(_expToLevel * _levelModifier);
	}
	
}
