using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public int maxHealth = 100;
	public int currentHealth = 100;
	public float healthBarLength;

	void Start()
	{
		healthBarLength = Screen.width / 2;
	}
	
	void Update()
	{
		AdjustHealth(0);
	}

	public void AdjustHealth(int portion)
	{
		currentHealth += portion;
		
		if (currentHealth < 0)
			currentHealth = 0;
		
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
		
		healthBarLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);
	}

}
