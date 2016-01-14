using UnityEngine;
using System.Collections;

public class TurretYRot : MonoBehaviour 
{
    //LOOK AT PLAYER LEFT & RIGHT
    //Turret Base

    private Transform target;
    private GameObject turret;
    private TurretRange turretrangeScript;

    void Start()
    {
        turret = GameObject.FindWithTag(Tags.turretTag);
        turretrangeScript = transform.parent.GetComponent<TurretRange>();
        //set target to player transform moving in range of turret range
        target = turretrangeScript.turretRange[0].transform;
    }

	void Update () 
    {
        //rotate to target over X & Z axis
        if(turretrangeScript.turretRange.Length > 0)
        {
            Vector3 targetPos = new Vector3(turretrangeScript.predictedPosition.x, transform.position.y, turretrangeScript.predictedPosition.z);
            transform.LookAt(targetPos);
            
        }
	}
}
