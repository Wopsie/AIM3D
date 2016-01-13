using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public enum State
	{
		PATROL,
		CHASE
	}
	public State state;

	private int layerMask;
	[HideInInspector]public Collider[] enemyRange;

	[SerializeField] private bool alive;

	public Transform[] waypoints;
	public Transform movingTo;
	public float speed;
	public float rotationSpeed = 2;
	public float maxSpeed;
	public int waypointIndex;
	private float mass =	150;

	void Start()
	{
		layerMask = LayerMask.GetMask("Player");

		alive = true;
		StartCoroutine("FSM");
		movingTo = waypoints[0];
		waypointIndex = 0;
		
		if(Vector3.Distance(transform.position, waypoints[0].position) < 1)
		{
			movingTo = waypoints[1];
			waypointIndex = 1;
		}
	}

	IEnumerator FSM()
	{
		while(alive)
		{
			switch(state)
			{
			case State.PATROL:
				Patrol();
				break;
			case State.CHASE:
				Chase();
				break;
			}
			yield return null;
		}
	}

	void Patrol()
	{
		if(Vector3.Distance(transform.position, movingTo.position) < 1)
		{
			if(waypointIndex == (waypoints.Length - 1))
			{
				waypointIndex = 0;
				movingTo = waypoints[waypointIndex];
			}
			else
			{
				waypointIndex++;
				movingTo = waypoints[waypointIndex];
			}
		}

		transform.position = Vector3.MoveTowards(transform.position, movingTo.position, Time.deltaTime * speed);

	}

	void Chase()
	{
		//Als de player binnen range komt achtervolg

	}
	
	void Attack()
	{
		//Als de player in range komt begin met schieten
	}

	void Update()
	{
		enemyRange = Physics.OverlapSphere(transform.position, 200f, layerMask);
		Debug.Log(enemyRange);


		Patrol();

		Vector3 desiredStep	= movingTo.position - GetComponent<Rigidbody>().position;
		desiredStep.Normalize();
		Vector3 desiredVelocity	= desiredStep	*	maxSpeed;
		Vector3 steeringForce = desiredVelocity - GetComponent<Rigidbody>().velocity;
		GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + steeringForce / mass;


		Vector3 targetDir = movingTo.position - transform.position;
		float step = rotationSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, 200f);
	}
}

