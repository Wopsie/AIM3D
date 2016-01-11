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
    private GameObject core;
    private CoreScript coreHealth;

	void Start () 
    {
        core = GameObject.FindWithTag(Tags.coreTag);
        coreHealth = core.GetComponent<CoreScript>();
        player = GameObject.FindWithTag(Tags.playerTag);
        pHealth = player.GetComponent<PlayerHealth>();
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
                pHealth.DecrHealth();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }else if(gameObject.tag == Tags.bBulletTag)
        {
            if(coll.gameObject.tag == Tags.coreTag)
            {
                Debug.Log("CORE HIT");
                coreHealth.DecreaseHealth();
            }
        }
        
    }
}