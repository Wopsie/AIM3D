using UnityEngine;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{	
	[SerializeField]    private float bulletDamage;
	private float speed = 600;
    private PlayerHealth pHealth;
    private GameObject player;
    private GameObject core;
    private GameObject turret;
    private CoreScript coreHealth;
    private TurretRange turretRangeScript;


	void Start () 
    {
        turret = GameObject.FindWithTag(Tags.turretTag);
        core = GameObject.FindWithTag(Tags.coreTag);
        player = GameObject.FindWithTag(Tags.playerTag);
        coreHealth = core.GetComponent<CoreScript>();
        pHealth = player.GetComponent<PlayerHealth>();
        turretRangeScript = turret.GetComponent<TurretRange>();
	}
	
	void Update () {
        //move bullet
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 4f);
	}

    

    void OnTriggerEnter(Collider coll)
    {
        //check for collision with building or asteroid
        if(coll.gameObject.tag == Tags.buildingTag || coll.gameObject.tag == Tags.asteroidTag)
        {
            Destroy(gameObject);
            Debug.Log("collision with building/asteroid");
        }
        //check if current bullet is red
        if(gameObject.tag == Tags.rBulletTag)
        {
            //check for collision with player
            if (coll.gameObject.tag == Tags.planeTag)
            {
                pHealth.DecrHealth();
                Destroy(gameObject);
                Debug.Log("Destroyed on player collision");
            }
            else
            {
                Destroy(gameObject);
            }
            //identify bullet through tag
        }else if(gameObject.tag == Tags.bBulletTag)
        {
            //check for collision with core
            if(coll.gameObject.tag == Tags.coreTag)
            {
                Debug.Log("CORE HIT");
                coreHealth.DecreaseHealth();
            }
        } 
    }
}