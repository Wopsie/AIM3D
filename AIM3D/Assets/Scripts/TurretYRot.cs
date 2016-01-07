using UnityEngine;
using System.Collections;

public class TurretYRot : MonoBehaviour 
{
    //LOOK AT PLAYER LEFT & RIGHT
    //Turret Base

    [SerializeField]    private Transform target;

    private GameObject turret;

    private TurretRange turretrangeScript;

    void Start()
    {
        turret = GameObject.FindWithTag(Tags.turretTag);
        turretrangeScript = turret.GetComponent<TurretRange>();  
    }

	void Update () 
    {
        //rotate to target over X & Z axis
        if(turretrangeScript.turretRange.Length > 0)
        {
            //this works
            Vector3 targetYPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            //transform.LookAt(targetYPos);

            //this is going to work
            Vector3 targetPos = new Vector3(Mathf.Sqrt(turretrangeScript.targetXPos), transform.position.y, turretrangeScript.targetZPos);
            transform.LookAt(targetPos);
            
        }else
        {
            //Debug.Log("no Y Target found");
        }
	}
}
