﻿using System.Collections.Generic;

public class ModifiedStat : BaseStat
{
	private List<ModifyingAttribute> _mods;
	private int _modValue;
	
	public ModifiedStat()
	{
		_mods = new List<ModifyingAttribute>();
		_modValue = 0;
	}
	
	public void AddModifier(ModifyingAttribute mod)
	{
		_mods.Add(mod);
	}
	
	private void CalulateModValue()
	{
		if (_modValue != 0)
			_modValue = 0;
			
		if (_mods.Count > 0)
			foreach(ModifyingAttribute att in _mods)
				_modValue += (int)(att.attribute.AdjustedBaseValue() * att.ratio);
	}
	
	public new int AdjustedBaseValue()
	{
		return BaseValue + BuffValue + _modValue;
	}
	
	public void Update()
	{
		CalulateModValue();
	}
	
}

public struct ModifyingAttribute
{
	public Attribute attribute;
	public float ratio;
	
	public ModifyingAttribute(Attribute att, float rat)
	{
		attribute = att;
		ratio = rat;
	}
	
}