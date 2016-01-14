﻿using UnityEngine;
using System.Collections;

public class PlayerHealthbar : MonoBehaviour {

    [SerializeField]
    private float healthScale;
    private float originalScaleX = 250f;

    void Start()
    {
        Plane.OnRenable += ResetScale;
    }

    void OnDisable()
    {
        Plane.OnRenable -= ResetScale;
    }

    public void DecreaseScale()
    {
        transform.localScale -= new Vector3(healthScale, 0, 0);
        Debug.Log("Deplete Healthbar");
    }

    public void ResetScale()
    {
        transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
    }
}
