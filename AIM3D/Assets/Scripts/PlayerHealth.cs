using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{

    [HideInInspector]   public int health = 10;

    private Explosion explosion;
    private DeathCamera dCam;
    private GameObject dCamera;
    private GameObject respawn;

    void Start()
    {
        explosion = GetComponent<Explosion>();
        dCamera = GameObject.FindWithTag(Tags.deathCam);
        dCam = dCamera.GetComponent<DeathCamera>();
    }


    public void DecrHealth()
    {
        //decrease health
        health -= 5;
        Debug.Log(health);
    }

    public void IncrHealth()
    {
        //increase health 
        health += 5;
        Debug.Log("heal");
    }

    public void NullHealth()
    {
        health -= health;
    }
    
    public void FullHealth()
    {
        health += 20;
        Debug.Log("FULL HEALTH");
    }

    void Update()
    {
        Debug.Log("player health is ... " + health);
        if (health <= 0)
        {
            Debug.Log("JE BENT HARSTIKKE DOOD");
            explosion.Death();
            //Camera.main.enabled = false;
            dCam.MoveCamBack();
            Destroy(gameObject);
        }       
    }
}
