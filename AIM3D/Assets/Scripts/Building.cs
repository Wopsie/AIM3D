using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {


    private PlayerHealth pHealth;
    private GameObject player;

	void Start () 
    {
        Plane.OnRenable += RefindPlayer;
	}

    void OnDisable()
    {
        Plane.OnRenable -= RefindPlayer;
    }

    public void RefindPlayer()
    {
        player = GameObject.FindWithTag(Tags.playerTag);
        pHealth = player.GetComponent<PlayerHealth>();
        Debug.Log(gameObject.tag + " found player");
    }
	
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == Tags.playerTag)
        {
            pHealth.NullHealth();
        }   
    }
}
