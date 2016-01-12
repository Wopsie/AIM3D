using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

    [SerializeField]    private GameObject player;
    private GameObject deathCamera;
    private Camera deathCam;
    private int lives = 3;
    private PlayerHealth pHealth;
    private GameObject tracker;
    private Camera trackerCam;
    private TrackerCam trackerScript;

    void Start()
    {
        tracker = GameObject.FindWithTag("MainCamera");
        trackerCam = tracker.GetComponent<Camera>();
        trackerScript = tracker.GetComponent<TrackerCam>();

        deathCamera = GameObject.FindWithTag(Tags.deathCam);
        deathCam = deathCamera.GetComponent<Camera>();
        pHealth = player.GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        //check for sufficient lives
        
        if(lives > 0)
        {
            //Debug.Log("respawning... " + lives);
            //add new player on respawn location & reenable main camera & disable deathcamera
            Instantiate(player, transform.position, transform.rotation);
            deathCam.enabled = false;
            Camera.main.enabled = true;
            trackerScript.RefindPlayer();
            lives--;
            Debug.Log(lives + " lives left");
        }
        else
        {
            //deathsceen
            Debug.Log("Mission Failed");
        }
        
    }
}
