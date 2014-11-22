using UnityEngine;
using System.Collections;

public class PlayerHealth : Health
{
	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, healthBarLength, 20), currentHealth + "/" + maxHealth);
	}
}
