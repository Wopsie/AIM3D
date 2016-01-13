using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    private float shakePower = 0.5f;
    private float duration = 0.5f;
    //private Vector3 initialPos;
    private bool isShaking = false;

	// Use this for initialization
	void Start () 
    {
        //initialPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(isShaking)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * shakePower;
        }
	}

    public void Shake()
    {
        isShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

    public void StopShaking()
    {
        isShaking = false;
    }
}
