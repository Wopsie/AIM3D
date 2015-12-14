using UnityEngine;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	[SerializeField]
	private float bulletDamage;
	private float speed = 20;
	public float Speed{get{return speed;}set{speed = value;}}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movementVector = this.transform.forward * (speed * Time.deltaTime);
		this.transform.position += movementVector;
	}
}
