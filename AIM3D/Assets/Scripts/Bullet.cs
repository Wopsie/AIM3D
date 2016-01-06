using UnityEngine;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{	
	[SerializeField]    private float bulletDamage;
	private float speed = 600;
	public float Speed{get{return speed;}set{speed = value;}}
    private PlayerHealth pHealth;
    private GameObject player;

    [SerializeField]    private AudioSource laserSound;

	void Start () 
    {
        player = GameObject.FindWithTag(Tags.playerTag);
        pHealth = player.GetComponent<PlayerHealth>();

        //laserSound.Play();
	}
	
	void Update () {
        //move bullet
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider coll)
    {
        //check if current bullet is red
        if(gameObject.tag == Tags.rBulletTag)
        {
            if (coll.gameObject.tag == Tags.planeTag)
            {
                //Debug.Log("collision with player");
                pHealth.DecrHealth();
                Destroy(gameObject);
            }
            else
            {
                //Debug.Log("fuck if i know");
                Destroy(gameObject);
            }
        }
        
    }
}