using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{	
	[SerializeField]    private float bulletDamage;
	private float speed = 20;
	public float Speed{get{return speed;}set{speed = value;}}

    private Plane player;
    private Quaternion bulletRot;
	
    void Start()
    {
        bulletRot = GetComponent<Plane>().transform.rotation;
    }

	void Update () {
        //move bullet
		//Vector3 movementVector = this.transform.forward * (speed * Time.deltaTime);
		//this.transform.position -= movementVector;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //rotate bullet
       // transform.eulerAngles = new Vector3(bulletRot.x, bulletRot.y, bulletRot.z);
	}
}
