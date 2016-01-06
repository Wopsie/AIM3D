using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{

    [HideInInspector]   public int health = 10;

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
        if (health <= 0)
            Debug.Log("JE BENT HARSTIKKE DOOD");
    }
}
