using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public GameObject target;
	public float attackTimer = 0.0f;
	public float coolDown = 2.0f;
	private PlayerHealth health;
	
	void Start()
	{
		health = target.GetComponent<PlayerHealth>();
	}
	
	void Update()
	{
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if (attackTimer <= 0)
		{
			attackTimer = coolDown;
			Attack();
		}
	}
	
	public void Attack()
	{
		float distance = Vector3.Distance(transform.position, target.transform.position);
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		int direction = (int)(Vector3.Dot(dir, transform.forward) + 0.5f);
	
		if (distance < 2.5 && direction > 0)
		{
			health.AdjustHealth(-10);
		}
	}
}
