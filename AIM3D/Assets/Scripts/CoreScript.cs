using UnityEngine;
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
        if(coreHealth <= 0)
        {
            Debug.Log("DESTROYED CORE");
            explosion.Death();
            Destroy(gameObject);
        }
    }

	public void DecreaseHealth()
    {
        cHealthBar.DecreaseScale();
        coreHealth -= 10;
    }
}
