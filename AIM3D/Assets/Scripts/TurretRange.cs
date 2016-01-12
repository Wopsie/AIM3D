using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretRange : MonoBehaviour 
{
    private int layerMask;
    [HideInInspector]   public Collider[] turretRange;
    private GameObject player;
    private Plane playerData;
    private LaserSight targetDistance;
    private Vector3 pRotation;
    private float playerPos;

    public Vector3 predictedPosition;
    private float posChange;

    //public Vector3 targetPos;

    [HideInInspector]   public float targetXPos;
    [HideInInspector]   public float targetYPos;
    [HideInInspector]   public float targetZPos;
    [HideInInspector]   public float travelTime;

    private float tDist;

    void Start()
    {
        layerMask = LayerMask.GetMask("Player");
        targetDistance = GetComponentInChildren<LaserSight>();
        player = GameObject.FindWithTag(Tags.playerTag);
        playerData = player.GetComponent<Plane>();
    }
	
	void Update () 
    {
        turretRange = Physics.OverlapSphere(transform.position, 600f, layerMask);

        
        //targetPos = new Vector3(pSpeed.speed, targetDistance.laserHit.distance, (pSpeed.speed * pSpeed.speed) + (targetDistance.laserHit.distance * targetDistance.laserHit.distance));

        //get target position & speed
        targetXPos = playerData.speed * playerData.speed;
        targetYPos = targetDistance.laserHit.distance*targetDistance.laserHit.distance;
        targetZPos = Mathf.Sqrt(targetXPos + targetYPos);

        travelTime = (Vector3.Distance(transform.position, player.transform.position) / 600f);

        pRotation = playerData.playerRot;

        playerPos = player.transform.position.sqrMagnitude;

        posChange = playerPos * travelTime;

        predictedPosition = pRotation * travelTime + player.transform.position;
        
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