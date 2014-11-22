using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targeting : MonoBehaviour 
{
	public List<Transform> targets;
	public Transform currentTarget;

	private Transform myTransform;

	void Start()
	{
		myTransform = transform;
		targets = new List<Transform>();
		AddEnemyTransforms();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
			TargetEnemy();
	}

	void AddEnemyTransforms()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in go)
		{
			AddTransform(enemy.transform);
		}

	}

	public void TargetEnemy()
	{
		if (currentTarget == null)
		{
			SortByDistance();	
			currentTarget = targets[0];
		}
		else
		{
			int index = targets.IndexOf(currentTarget);
			
			if (index  < targets.Count - 1)
				++index;
            else
				index = 0;
			
			DeselectTarget();
			currentTarget = targets[index];    
		}
		SelectTarget();
	}

	void AddTransform(Transform enemyTransform)
	{
		targets.Add(enemyTransform);
	}

	private void SortByDistance()
	{
		targets.Sort(delegate(Transform t1, Transform t2){
			return Vector3.Distance(t1.position, myTransform.position)
						  .CompareTo(Vector3.Distance(t2.position, myTransform.position));
		});
	}

	private void SelectTarget()
	{
		currentTarget.renderer.material.color = Color.red;
		
		PlayerAttack aAttack = GetComponent<PlayerAttack>();
		aAttack.SetTarget(currentTarget.gameObject);
	}
	
	private void DeselectTarget()
	{
		currentTarget.renderer.material.color = Color.white;
	}

}
