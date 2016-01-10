using UnityEngine;
using System.Collections;

public class PatrolBehaviour : MonoBehaviour {

	public Transform[] waypoints;
	public Transform movingTo;
	public float speed;
	public float maxSpeed;
	public int waypointIndex;
	private float mass		=	150;


	void Start()
	{
		movingTo = waypoints[0];
		waypointIndex = 0;

		if(Vector3.Distance(transform.position, waypoints[0].position) < 1)
		{
			movingTo = waypoints[1];
			waypointIndex = 1;
		}


	}

	void FixedUpdate()
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

		Vector3 desiredStep	= movingTo.position - GetComponent<Rigidbody>().position;
		desiredStep.Normalize();
		Vector3 desiredVelocity	= desiredStep	*	maxSpeed;
		Vector3 steeringForce = desiredVelocity - GetComponent<Rigidbody>().velocity;
		GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + steeringForce / mass;

		transform.position = Vector3.MoveTowards(transform.position, movingTo.position, Time.deltaTime * speed);

		Vector3 targetDir = movingTo.position - transform.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		//.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);

		//Vector3 relativePos = movingTo.position - transform.position;
		//Quaternion rotation = Quaternion.LookRotation(desiredStep);
		//transform.rotation = rotation;
	}
}
