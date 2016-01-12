using UnityEngine;
using System.Collections;

public class TurretXRot : MonoBehaviour 
{
    //LOOK AT PLAYER UP & DOWN
    //Turret Nuzzle

    [SerializeField]    private Transform target;
    private Shooter shootClass;
    private int shootCoolDown;
    private TurretRange turretRangeScript;
    private GameObject turret;
    private bool targetVisible;

    private Lines line;
    private GameObject lines;

    void Start()
    {
        line = GetComponent<Lines>();
        lines = GetComponent<Lines>().makeLine(Vector3.up, Color.red);
        turret = GameObject.FindWithTag(Tags.turretTag);
        shootClass = GetComponentInChildren<Shooter>();
        turretRangeScript = turret.GetComponent<TurretRange>();
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
            //this works
            Vector3 targetYPos = new Vector3(target.position.x, target.position.y, target.position.z);
            //transform.LookAt(targetYPos);

            //this is going to work
            Vector3 targetPos = new Vector3(Mathf.Sqrt(turretRangeScript.targetXPos), Mathf.Sqrt(turretRangeScript.targetYPos), turretRangeScript.targetZPos) + targetYPos;
            transform.LookAt(targetPos);


            line.drawLineTo(lines,transform.position, turretRangeScript.predictedPosition);

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
