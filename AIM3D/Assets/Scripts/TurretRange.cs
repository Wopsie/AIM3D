using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretRange : MonoBehaviour 
{
    private int layerMask;
    [HideInInspector]   public Collider[] turretRange;
    private GameObject player;
    private Plane pSpeed;
    private LaserSight targetDistance;

    public Vector3 targetPos;

    private float tDist;

    void Start()
    {
        layerMask = LayerMask.GetMask("Player");
        targetDistance = GetComponentInChildren<LaserSight>();
        player = GameObject.FindWithTag(Tags.playerTag);
        pSpeed = player.GetComponent<Plane>();
    }
	
	void Update () 
    {
        turretRange = Physics.OverlapSphere(transform.position, 600f, layerMask);
        Debug.Log("turret range is: " + turretRange);

        targetPos = new Vector3(pSpeed.speed, targetDistance.laserHit.distance, (pSpeed.speed * pSpeed.speed) + (targetDistance.laserHit.distance * targetDistance.laserHit.distance));

        //Debug.Log("target position is: " + targetPos);
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 600f);
    }




    //player speed = pSpeed.speed
    //player distance = targetDistance.laserHit.Distance


    //(pSpeed.speed * pSpeed.speed) + (targetDistnace.laserHit.Distance * targetDistnace.laserHit.Distance)
}