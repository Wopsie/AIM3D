using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerTest : MonoBehaviour {
	
	[SerializeField]    private GameObject bullet;
	public float speed = 10;

	public enum Projectile
	{
		Bullet
	}

	public Dictionary<Projectile, GameObject> shooter = new Dictionary<Projectile, GameObject>();
	private Projectile shoot;

	void Start()
	{
		shooter.Add(Projectile.Bullet, bullet);
	}

	
	// Update is called once per frame
	void Update () {
		float rightTrigger = Input.GetAxis ("RightTrigger");
		float leftTrigger = Input.GetAxis ("LeftTrigger");

		//Keycodes are for dev use only!
		if(rightTrigger > 0 || Input.GetKeyDown(KeyCode.M))
		{
			Debug.Log ("RightTrigger Pressed");
			var clone = (GameObject)Instantiate(shooter[shoot], transform.position, Quaternion.identity);
			//Shoot
		}
		if(leftTrigger > 0 || Input.GetKeyDown(KeyCode.N))
		{
			Debug.Log ("LeftTrigger Pressed");
			//Aim??
		}
		if(rightTrigger == 0 && leftTrigger == 0)
		{
			Debug.Log("<color=red>Nothing is Pressed</color>");
			//No triggers pressed
		}
		else if(rightTrigger > 0 && leftTrigger > 0)
		{
			Debug.Log("Both are pressed");
		}
	}
}
