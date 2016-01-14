using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
	public float speed = 10f;
    private GameObject player;
    private PlayerHealth pHealth;

    void Start()
    {
        Plane.OnRenable += RefindPlayer;
    }

	void Update ()
	{
        //rotate asteroids
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
		transform.Rotate(Vector3.right, speed * Time.deltaTime);
	}

    void RefindPlayer()
    {
        //get player instance
        player = GameObject.FindWithTag(Tags.playerTag);
        pHealth = player.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter(Collision coll)
    {
        //check for collision with player
        if(coll.gameObject.tag == Tags.playerTag)
        {
            pHealth.NullHealth();
        }
    }
}