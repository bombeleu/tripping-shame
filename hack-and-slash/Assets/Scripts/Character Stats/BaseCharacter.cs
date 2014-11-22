using UnityEngine;
using System.Collections;

public class BaseCharacter : MonoBehaviour 
{
	private string _name;
	private int _level;
	private uint _freeExp;
	
	private Attribute[] _primaryAttribute;
	private Vital[] _vitals;
	private Skill[] _skills;
	
	public void Awake()
	{
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;
		
		_primaryAttribute = new Attribute[System.Enum.GetValues(typeof(AttributeNames)).Length];
		_vitals = new Vital[System.Enum.GetValues(typeof(VitalNames)).Length];
		_skills = new Skill[System.Enum.GetValues(typeof(SkillName)).Length];
		
		SetUpPrimaryAttributes();
		SetUpVitals();
		SetUpSkills();
	}
	
	#region basic setters and getters
	public string Name
	{
		get{ return _name; }
		set{ _name = value; }
	}
	
	public int Level
	{
		get{ return _level; }
		set{ _level = value; }
	}
	
	public uint FreeExp
	{
		get{ return _freeExp; }
		set{ _freeExp = value; }
	}
	#endregion
	
	public void AddExp(uint exp)
	{
		_freeExp += exp;
		CalculateLevel();
	}
	
	public void CalculateLevel()
	{
		
	}
	
	private void SetUpPrimaryAttributes()
	{
		for (int cnt = 0; cnt < _primaryAttribute.Length; ++cnt)
			_primaryAttribute[cnt] = new Attribute();
	}
	
	private void SetUpVitals()
	{
		for (int cnt = 0; cnt < _vitals.Length; ++cnt)
			_vitals[cnt] = new Vital();
			
		SetUpVitalModifiers();
	}
	
	private void SetUpSkills()
	{
		for (int cnt = 0; cnt < _skills.Length; ++cnt)
			_skills[cnt] = new Skill();
			
		SetUpSkillModifiers();
	}
	
	public Attribute GetPrimaryAttribute(int index)
	{
		return _primaryAttribute[index];
	}
	
	public Vital GetVital(int index)
	{
		return _vitals[index];
	}
	
	public Skill GetSkill(int index)
	{
		return _skills[index];
	}
	
	private void SetUpVitalModifiers()
	{
		//health
		AddVitalMod(VitalNames.Health, AttributeNames.Constitution, 0.5f);
		
		//energy
		AddVitalMod(VitalNames.Energy, AttributeNames.Constitution, 1);
		
		//mana
		AddVitalMod(VitalNames.Mana, AttributeNames.Willpower, 1);
	}
	
	private void SetUpSkillModifiers()
	{
		//Melee Offence
		AddSkillMod(SkillName.Melee_Offence, AttributeNames.Strength, 0.33f);
		AddSkillMod(SkillName.Melee_Offence, AttributeNames.Dexterity, 0.33f);
		
		//Melee Defence
		AddSkillMod(SkillName.Melee_Defence, AttributeNames.Speed, 0.33f);
		AddSkillMod(SkillName.Melee_Defence, AttributeNames.Constitution, 0.33f);
		
		//Magic Offence
		AddSkillMod(SkillName.Magic_Offence, AttributeNames.Concentration, 0.33f);
		AddSkillMod(SkillName.Magic_Offence, AttributeNames.Willpower, 0.33f);
		
		//Magic Defence
		AddSkillMod(SkillName.Magic_Defence, AttributeNames.Concentration, 0.33f);
		AddSkillMod(SkillName.Magic_Defence, AttributeNames.Willpower, 0.33f);
		
		//Ranged Offence
		AddSkillMod(SkillName.Ranged_Offence, AttributeNames.Concentration, 0.33f);
		AddSkillMod(SkillName.Ranged_Offence, AttributeNames.Speed, 0.33f);
		
		//Ranged Defence
		AddSkillMod(SkillName.Ranged_Defence, AttributeNames.Speed, 0.33f);
		AddSkillMod(SkillName.Ranged_Defence, AttributeNames.Dexterity, 0.33f);
	}
	
	private void AddVitalMod(VitalNames vital, AttributeNames att, float ratio)
	{
		GetVital((int)vital).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)att), ratio));
	}
	
	private void AddSkillMod(SkillName skill, AttributeNames att, float ratio)
	{
		GetSkill((int)skill).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)att), ratio));
	}
	
	public void StatUpdate()
	{
		for (int i = 0; i < _vitals.Length; ++i)
			_vitals[i].Update();
			
		for (int i = 0; i < _skills.Length; ++i)
			_skills[i].Update();
	}
	
}
