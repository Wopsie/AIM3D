using UnityEngine;
using System.Collections;

public class TurretXRot : MonoBehaviour 
{
    //LOOK AT PLAYER UP & DOWN
    //Turret Nuzzle

    [SerializeField]    private Transform target;
    private Shooter shootClass;

    void Start()
    {
        shootClass = GetComponentInChildren<Shooter>();
    }

    void Update()
    {
        Vector3 targetYPos = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.LookAt(targetYPos);

        shootClass.Shoot();

        if(transform.rotation.eulerAngles.x >15f && transform.rotation.eulerAngles.x <180)
        {
            transform.eulerAngles = new Vector3(15f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
