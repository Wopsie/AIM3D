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
            Vector3 targetYPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            //Vector3 targetYPos = turretrangeScript.targetPos;
            transform.LookAt(targetYPos);
        }else
        {
            //Debug.Log("no Y Target found");
        }
	}
}
