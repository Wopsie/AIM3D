using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{

    [HideInInspector]   private int health = 25;

    private Explosion explosion;
    private DeathCamera dCam;
    private HealthBar pHealthBarScript;
    private GameObject dCamera;
    private GameObject respawn;
    private GameObject pHealthBar;
    

    void Start()
    {
        pHealthBar = GameObject.FindWithTag(Tags.playerHealthbar);
        pHealthBarScript = pHealthBar.GetComponent<HealthBar>();

        explosion = GetComponent<Explosion>();

        dCamera = GameObject.FindWithTag(Tags.deathCam);
        dCam = dCamera.GetComponent<DeathCamera>();
    }


    public void DecrHealth()
    {
        //decrease health
        health -= 5;
        pHealthBarScript.DecreaseScale();
    }

    public void NullHealth()
    {
        health -= health;
    }
    
    public void FullHealth()
    {
        health += 25;
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
