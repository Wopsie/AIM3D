using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{

    [HideInInspector]   private int health = 25;

    private Explosion explosion;
    private DeathCamera dCam;
    private PlayerHealthbar pHealthBarScript;
    private CameraShake camShake;
    private GameObject dCamera;
    private GameObject respawn;
    private GameObject pHealthBar;
    

    void Start()
    {
        pHealthBar = GameObject.FindWithTag(Tags.playerHealthbar);
        pHealthBarScript = pHealthBar.GetComponent<PlayerHealthbar>();

        explosion = GetComponent<Explosion>();

        dCamera = GameObject.FindWithTag(Tags.deathCam);
        dCam = dCamera.GetComponent<DeathCamera>();

        camShake = Camera.main.GetComponent<CameraShake>();
    }


    public void DecrHealth()
    {
        //decrease health
        health -= 5;
        pHealthBarScript.DecreaseScale();
        camShake.Shake();
    }

    public void NullHealth()
    {
        //remove all remaining health
        health -= health;
    }
    
    public void FullHealth()
    {
        //reset health to full
        health += 25;
        Debug.Log("FULL HEALTH");
    }

    void Update()
    {
        Debug.Log("player health is ... " + health);
        //if health is zero say *boom*
        if (health <= 0)
        {
            Debug.Log("JE BENT HARSTIKKE DOOD");
            explosion.Death();
            dCam.MoveCamBack();
            Destroy(gameObject);
        }       
    }
}
