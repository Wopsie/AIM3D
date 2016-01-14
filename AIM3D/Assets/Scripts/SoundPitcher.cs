using UnityEngine;
using System.Collections;

public class SoundPitcher : MonoBehaviour {

    [SerializeField]
    private AudioSource engineSound;
    private Plane plane;
    public float maxPitch;
    public float minPitch;

	void Start () {
        plane = GetComponent<Plane>();
	}
	
	void Update () 
    {
        //check if controller A button is pushed
        if(Input.GetButton("A"))
        {
            //increase engine sound pitch untill max
            engineSound.pitch += Time.deltaTime * 2f;
            if(engineSound.pitch > maxPitch)
            {
                engineSound.pitch = maxPitch;
            }
        }
        else
        {
            //if controller A button is released lower pitch untill minimum
            engineSound.pitch -= Time.deltaTime * 2;
            if(engineSound.pitch < minPitch)
            {
                engineSound.pitch = minPitch;
            }
        }
	}
}
