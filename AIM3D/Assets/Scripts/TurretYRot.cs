using UnityEngine;
using System.Collections;

public class TurretYRot : MonoBehaviour 
{
    //LOOK AT PLAYER LEFT & RIGHT
    //Turret Base

    [SerializeField]    private Transform target;

	void Update () 
    {
        Vector3 targetYPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetYPos);
	}
}
