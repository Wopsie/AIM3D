using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerTest : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [HideInInspector]   public float speed = 10;

    private Shooter shootClass;
    private int shootCoolDown;

    void Start()
    {
        shootClass = GetComponentInChildren<Shooter>();
    }

    //reduce cooldown for shooting untill zero
    void FixedUpdate()
    {
        shootCoolDown--;
        if (shootCoolDown < 0)
        {
            shootCoolDown = 0;
        }
    }

    void Update()
    {
        float rightTrigger = Input.GetAxis("RightTrigger");
        float leftTrigger = Input.GetAxis("LeftTrigger");

        //Keycodes are for dev use only!
        if (rightTrigger > 0.9 || Input.GetKeyDown(KeyCode.M))
        {
            if (shootCoolDown == 0)
            {
                shootClass.Shoot();
                shootCoolDown = 10;
                //Shoot
            }   
        }
        //check left trigger
        if (leftTrigger > 0 || Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("LeftTrigger Pressed");
            //Aim??
        }
    }
}


