using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform target;
	public float speed;
	public float rotationSpeed;
	public float maxDistance = 2.0f;

	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		Debug.DrawLine(target.position, myTransform.position, Color.red);

		//Look in our direction
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(
						target.position - myTransform.position), rotationSpeed * Time.deltaTime);

		//Move towards player
		if (Vector3.Distance(target.position, myTransform.position) > 2.0f)
		{
			myTransform.position += myTransform.forward * speed * Time.deltaTime;
		}
	}

}
