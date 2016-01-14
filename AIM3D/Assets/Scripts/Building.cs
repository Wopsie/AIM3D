using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {


    private PlayerHealth pHealth;
    private GameObject player;

	void Start () 
    {
        //run refindplayer upon receiving event from player
        Plane.OnRenable += RefindPlayer;
	}

    void OnDisable()
    {
        Plane.OnRenable -= RefindPlayer;
    }

    public void RefindPlayer()
    {
        //get player instance
        player = GameObject.FindWithTag(Tags.playerTag);
        pHealth = player.GetComponent<PlayerHealth>();
        Debug.Log(gameObject.tag + " found player");
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
