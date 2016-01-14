﻿using UnityEngine;
using System.Collections;

public class CoreScript : MonoBehaviour {

    private int coreHealth = 100;
    private Explosion explosion;
    private GameObject cHealth;
    private HealthBar cHealthBar;

    void Start()
    {
        cHealth = GameObject.FindWithTag(Tags.coreHealthbar);
        cHealthBar = cHealth.GetComponent<HealthBar>();
        explosion = GetComponent<Explosion>();
    }

    void Update()
    {
        //if core health is zero destroy core
        if(coreHealth <= 0)
        {
            Debug.Log("DESTROYED CORE");
            explosion.Death();
            Destroy(gameObject);

            StartCoroutine("WinScreen");
        }
    }

    IEnumerator WinScreen()
    {
        for (int i = 0; i > 120; i++)
        {
            yield return new WaitForSeconds(3f);
        }
		
        //switch scene to winscene
        Debug.Log("WINSCREEN");
        Application.LoadLevel("WinScene"); 
        yield return new WaitForSeconds(0f);    
    }

    //decrease health
	public void DecreaseHealth()
    {
        cHealthBar.DecreaseScale();
        coreHealth -= 10;
        Debug.Log("decrease core health");
    }
}
