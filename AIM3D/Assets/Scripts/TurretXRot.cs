using UnityEngine;
using System.Collections;

public class TurretXRot : MonoBehaviour 
{
    //LOOK AT PLAYER UP & DOWN
    //Turret Nuzzle

    private Transform target;
    private Shooter shootClass;
    private int shootCoolDown;
    private TurretRange turretRangeScript;
    [SerializeField]    private GameObject turret;
    private bool targetVisible;


    void Start()
    {
        shootClass = GetComponentInChildren<Shooter>();
        turretRangeScript = turret.GetComponent<TurretRange>();
        target = turretRangeScript.turretRange[0].transform;
    }

    void FixedUpdate()
    {
        shootCoolDown--;
        if(shootCoolDown < 0)
        {
            shootCoolDown = 0;
        }
    }

    void Update()
    {
        
        //if object is within range
        if(turretRangeScript.turretRange.Length > 0)
        {
            //rotate to target
            Vector3 targetPos = new Vector3(turretRangeScript.predictedPosition.x, turretRangeScript.predictedPosition.y, turretRangeScript.predictedPosition.z);
            transform.LookAt(targetPos);

            //check if target is not too low and if cooldown is zero
            if (shootCoolDown == 0 && targetVisible == true)
            {
                shootClass.Shoot();
                shootCoolDown = 10;
            }

            //stop rotation at certain angle
            if (transform.rotation.eulerAngles.x > 15f && transform.rotation.eulerAngles.x < 180)
            {
                transform.eulerAngles = new Vector3(15f, transform.eulerAngles.y, transform.eulerAngles.z);
                targetVisible = false;
            }else
            {
                targetVisible = true;
            }
        }
        else
        {
            //Debug.Log("no X Target found");
        }

        
    }
}
