using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretRange : MonoBehaviour 
{
    private int layerMask;
    [HideInInspector]   public Collider[] turretRange;
    [HideInInspector]   public GameObject player;
    private Plane playerData;
    private LaserSight targetDistance;
    private Vector3 pRotation;
    private float playerPos;

    public Vector3 predictedPosition;
    private float posChange;

    [HideInInspector]   public float targetXPos;
    [HideInInspector]   public float targetYPos;
    [HideInInspector]   public float targetZPos;
    [HideInInspector]   public float travelTime;

    private float tDist;

    void Start()
    {
        Plane.OnRenable += RefindPlayer;

        layerMask = LayerMask.GetMask("Player");
        targetDistance = GetComponentInChildren<LaserSight>();
    }

    void OnDisable()
    {
        Plane.OnRenable -= RefindPlayer;
    }
	
	void Update () 
    {
        turretRange = Physics.OverlapSphere(transform.position, 650f, layerMask);

        if (playerData != null && turretRange != null)
        {
            //get player position
            Vector3 playerPos = turretRange[0].transform.position;
            //get bullet speed
            float bulletSpeed = 600f * Time.fixedDeltaTime;
            //calculate distance to player with pythagoras
            float playerDistance = Vector3.Distance(transform.position, playerPos);
            //calculate traveltime
            travelTime = playerDistance / bulletSpeed;
            predictedPosition = playerPos + playerData.movementVector * travelTime;
        }
	}

    public void RefindPlayer()
    {
        player = GameObject.FindWithTag(Tags.playerTag);
        playerData = player.GetComponent<Plane>();
    }

    public void DestroyTurret()
    {
        int health = 20;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 650f);
    
     */
}