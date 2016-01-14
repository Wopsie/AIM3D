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
        //send out raycast untill something is hit
        if(Physics.Raycast(transform.position, transform.forward, out laserHit))
        {
            //if raycast hits collider set end position of linerenderer to position of collider
            if(laserHit.collider)
            {
                laser.SetPosition(1, new Vector3(0, 0, laserHit.distance));
            }
        }
	}
}