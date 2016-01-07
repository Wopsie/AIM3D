using UnityEngine;
using System.Collections;

public class SoundPitcher : MonoBehaviour {

    [SerializeField]
    private AudioSource engineSound;
    private Plane plane;
    public float maxPitch;
    public float minPitch;

	// Use this for initialization
	void Start () {
        plane = GetComponent<Plane>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetButton("A"))
        {
            
            engineSound.pitch += Time.deltaTime * 2f;
            if(engineSound.pitch > maxPitch)
            {
                engineSound.pitch = maxPitch;
            }
        }
        else
        {
            engineSound.pitch -= Time.deltaTime * 2;
            if(engineSound.pitch < minPitch)
            {
                engineSound.pitch = minPitch;
            }
            
        }
	}
}
