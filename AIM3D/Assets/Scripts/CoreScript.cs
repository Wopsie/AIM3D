using UnityEngine;
using System.Collections;

public class CoreScript : MonoBehaviour {

    private int coreHealth = 100;
    private Explosion explosion;
    private GameObject cHealth;
    private HealthBar cHealthBar;
    private ChangeScene changeScene;
    private GameObject SceneSwitcher;

    void Start()
    {
        SceneSwitcher = GameObject.Find("SceneSwitcher");
        changeScene = SceneSwitcher.GetComponent<ChangeScene>();
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
            changeScene.ChangeSceneAfter();
            Destroy(gameObject);

            
        }
    }

    //decrease health
	public void DecreaseHealth()
    {
        cHealthBar.DecreaseScale();
        coreHealth -= 10;
        Debug.Log("decrease core health");
    }
}
