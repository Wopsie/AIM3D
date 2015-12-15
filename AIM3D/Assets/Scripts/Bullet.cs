using UnityEngine;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{	
	[SerializeField]    private float bulletDamage;
	private float speed = 750;
	public float Speed{get{return speed;}set{speed = value;}}

	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        //move bullet
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
