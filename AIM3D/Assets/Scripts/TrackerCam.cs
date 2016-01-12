using UnityEngine;
using System.Collections;

public class TrackerCam : MonoBehaviour 
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag(Tags.playerTag);
    }

	void FixedUpdate () 
    {
        if(player != null)
        {
            //track player with camera
            Vector3 moveCamTo = player.transform.position - player.transform.forward * 10f + Vector3.up * 5f;
            float bias = 0.80f;
            Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1f - bias);
            Camera.main.transform.LookAt(player.transform.position + player.transform.forward * 60f);
        }
        
	}

    public void RefindPlayer()
    {
        player = GameObject.FindWithTag(Tags.playerTag);
        Debug.Log(player + "found player");
    }
}
