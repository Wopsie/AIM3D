using UnityEngine;
using System.Collections;

public class LaserSight : MonoBehaviour {

    private LineRenderer laser;
    public RaycastHit laserHit;

	void Start () 
    {
        laser = GetComponent<LineRenderer>();
	}
	
	void Update () 
    {
        if(Physics.Raycast(transform.position, transform.forward, out laserHit))
        {
            if(laserHit.collider)
            {
                laser.SetPosition(1, new Vector3(0, 0, laserHit.distance));
                Debug.Log(laserHit.distance);
            }
        }
        else
        {
            laser.SetPosition(1, new Vector3(0, 0, 50));
        }
	}
}
