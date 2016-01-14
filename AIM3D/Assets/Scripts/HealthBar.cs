using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    [SerializeField]    private float healthScale;

    public void DecreaseScale()
    {
        transform.localScale -= new Vector3(healthScale, 0, 0);
        Debug.Log("Deplete Healthbar");
    }
}
