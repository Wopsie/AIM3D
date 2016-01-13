using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

    [SerializeField]    private GameObject player;
    private GameObject deathCamera;
    private GameObject tracker;
    private GameObject building;
    private GameObject turret;
    private Camera deathCam;
    private Camera trackerCam;
    private int lives = 3;
    private PlayerHealth pHealth;
    private TrackerCam trackerScript;
    private Building buildingScript;
    private TurretRange turretScript;
    private DeathCamera deathCamScript;

    void Start()
    {
        tracker = GameObject.FindWithTag("MainCamera");
        trackerCam = tracker.GetComponent<Camera>();
        trackerScript = tracker.GetComponent<TrackerCam>();

        deathCamera = GameObject.FindWithTag(Tags.deathCam);
        deathCam = deathCamera.GetComponent<Camera>();
        deathCamScript = deathCamera.GetComponent<DeathCamera>();

        pHealth = player.GetComponent<PlayerHealth>();

        building = GameObject.FindWithTag(Tags.buildingTag);
        buildingScript = building.GetComponent<Building>();

        turret = GameObject.FindWithTag(Tags.turretTag);
        turretScript = turret.GetComponent<TurretRange>();
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
            //turret
            //building
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
