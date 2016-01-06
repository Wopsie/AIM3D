using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {


    private PlayerHealth pHealth;
    private GameObject player;

	void Start () {
        player = GameObject.FindWithTag(Tags.playerTag);
        pHealth = player.GetComponent<PlayerHealth>();
	}
	
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == Tags.playerTag)
        {
            pHealth.NullHealth();
            Debug.Log("collision with building");
        }
    }
}
