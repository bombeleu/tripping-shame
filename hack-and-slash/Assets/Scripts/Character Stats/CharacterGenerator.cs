using UnityEngine;
using System.Collections;

public class CharacterGenerator : MonoBehaviour 
{
	private PlayerCharacter _toon;
	private const int START_POINTS = 350;
	private const int MIN_STARTING_VALUE = 10;
	private const int STARTING_VALUE = 50;
	private int pointsLeft;
	
	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;
	
	private const int STAT_LABEL_WIDTH = 100;
	private const int BASE_VALUE_WIDTH = 30;
	
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;
	
	private const int STAT_STARTING_POS = 40;
	
	public GUISkin mySkin;
	
	public GameObject playerPrefab;
	
	
	void Start()
	{
		GameObject pc = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
		pc.name = "Player";
	
		//_toon = new PlayerCharacter();
		//_toon.Awake();
		
		_toon = pc.GetComponent<PlayerCharacter>();
		
		pointsLeft = START_POINTS;
		
		for (int i = 0; i < System.Enum.GetValues(typeof(AttributeNames)).Length; ++i)
		{
			_toon.GetPrimaryAttribute(i).BaseValue = STARTING_VALUE;
			pointsLeft -= (STARTING_VALUE - MIN_STARTING_VALUE);
		}
			
		_toon.StatUpdate();
	}

	void OnGUI()
	{
		GUI.skin = mySkin;
		DisplayName();
		DisplayPointsLeft();
		DisplayAttributes();
		DisplayVitals();
		DisplaySkills();
		DisplayCreateButton();
	}
	
	private void DisplayName()
	{
		GUI.Label(new Rect(10,10, 50, 25), "Name:");
		          _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
	}
	
	private void DisplayAttributes()
	{
		for (int i = 0; i < System.Enum.GetValues(typeof(AttributeNames)).Length; ++i)
		{
			GUI.Label(new Rect(OFFSET, STAT_STARTING_POS + (i * LINE_HEIGHT),STAT_LABEL_WIDTH, LINE_HEIGHT), ((AttributeNames)i).ToString());
			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET, STAT_STARTING_POS + (i * LINE_HEIGHT), BASE_VALUE_WIDTH, LINE_HEIGHT), 
			          _toon.GetPrimaryAttribute(i).AdjustedBaseValue().ToString());
			          
			if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_WIDTH, 
				STAT_STARTING_POS + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "-"))
			{
				if (_toon.GetPrimaryAttribute(i).BaseValue > MIN_STARTING_VALUE)
				{
					_toon.GetPrimaryAttribute(i).BaseValue--;
					++pointsLeft;
					_toon.StatUpdate();
				}
			}
			
			if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_WIDTH + BUTTON_WIDTH , 
					STAT_STARTING_POS + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "+"))
			{
				if (pointsLeft > 0)
				{
					_toon.GetPrimaryAttribute(i).BaseValue++;
					--pointsLeft;
					_toon.StatUpdate();
				}
			}
		}
	}
	
	private void DisplayVitals()
	{
		for (int i = 0; i < System.Enum.GetValues(typeof(VitalNames)).Length; ++i)
		{
			GUI.Label(new Rect(OFFSET, STAT_STARTING_POS + ((i + 7) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalNames)i).ToString());
			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET, STAT_STARTING_POS + ((i + 7) * LINE_HEIGHT), BASE_VALUE_WIDTH, LINE_HEIGHT), 
			          _toon.GetVital(i).AdjustedBaseValue().ToString());
		}
	}
	
	private void DisplaySkills()
	{
		for (int i = 0; i < System.Enum.GetValues(typeof(SkillName)).Length; ++i)
		{
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2, 
					  STAT_STARTING_POS + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName)i).ToString());
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2 + STAT_LABEL_WIDTH,
					  STAT_STARTING_POS + (i * LINE_HEIGHT), BASE_VALUE_WIDTH, LINE_HEIGHT), _toon.GetSkill(i).AdjustedBaseValue().ToString());
		}
	}
	
	private void DisplayPointsLeft()
	{
		GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft); 
	}
	
	private void DisplayCreateButton()
	{
		if (GUI.Button(new Rect(Screen.width / 2 - 50, STAT_STARTING_POS + 10 * LINE_HEIGHT,
					   100, LINE_HEIGHT), "Create"))
		{
			Application.LoadLevel ("Main");
		}
	}
	
}
