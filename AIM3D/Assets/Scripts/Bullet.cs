using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{	
	[SerializeField]    private float bulletDamage;
	private float speed = 1000;
	public float Speed{get{return speed;}set{speed = value;}}

	void Update () {
        //move bullet
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
