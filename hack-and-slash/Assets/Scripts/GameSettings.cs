using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour 
{
	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void SaveCharacterData()
	{
		GameObject pc = GameObject.Find("pc");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
		PlayerPrefs.SetString("Player Name", pcClass.name);
	}
	
	void LoadCharacterData()
	{
	
	}
}
