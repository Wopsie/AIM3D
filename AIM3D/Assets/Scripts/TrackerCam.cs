using UnityEngine;
using System.Collections;

public class TrackerCam : MonoBehaviour {

    [SerializeField]    private Transform player;
	
	void FixedUpdate () 
    {
        //track player with camera
        Vector3 moveCamTo = player.position - player.forward * 10f + Vector3.up * 5f;
        float bias = 0.80f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1f - bias);
        Camera.main.transform.LookAt(player.position + player.forward * 60f);
	}
}
