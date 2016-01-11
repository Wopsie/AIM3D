using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{

    [HideInInspector]   public int health = 10;

    private Explosion explosion;
    private DeathCamera dCam;
    private GameObject dCamera;

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
    }

    public void NullHealth()
    {
        health -= health;
        Debug.Log("GET DUNKED ON!");
    }

    void Update()
    {
        Debug.Log(health);
        if (health <= 0)
        {
            Debug.Log("JE BENT HARSTIKKE DOOD");
            explosion.Death();
            //dCam.MoveCamBack();
            Destroy(gameObject);
        }       
    }
}
