using UnityEngine;
using System.Collections;

public class EnemyHealth : Health
{
	void OnGUI()
	{
		GUI.Box(new Rect(10, 35, healthBarLength, 20), currentHealth + "/" + maxHealth);
	}
}
