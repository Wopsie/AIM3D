using UnityEngine;
using System.Collections;

public class PatrolBehaviour : MonoBehaviour {

	public enum State
	{
		PATROL,
		CHASE
	}
	public State state;

	[SerializeField] private bool alive;

	public Transform[] waypoints;
	public Transform movingTo;
	public float speed;
	public float maxSpeed;
	public int waypointIndex;
	private float mass		=	150;


	void Start()
	{
		StartCoroutine("FSM");
		Patrol();
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
		movingTo = waypoints[0];
		waypointIndex = 0;
		
		if(Vector3.Distance(transform.position, waypoints[0].position) < 1)
		{
			movingTo = waypoints[1];
			waypointIndex = 1;
		}

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
		Debug.Log("CHASE!");
	}

	void Update()
	{
		Vector3 desiredStep	= movingTo.position - GetComponent<Rigidbody>().position;
		desiredStep.Normalize();
		Vector3 desiredVelocity	= desiredStep	*	maxSpeed;
		Vector3 steeringForce = desiredVelocity - GetComponent<Rigidbody>().velocity;
		GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + steeringForce / mass;


		Vector3 targetDir = movingTo.position - transform.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);
	}
}

