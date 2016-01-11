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
            //Debug.Log("RightTrigger Pressed");

            if (shootCoolDown == 0)
            {
                shootClass.Shoot();
                shootCoolDown = 10;
                //Shoot
            }   
        }
        if (leftTrigger > 0 || Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("LeftTrigger Pressed");
            //Aim??
        }
        if (rightTrigger == 0 && leftTrigger == 0)
        {
            Debug.Log("<color=red>Nothing is Pressed</color>");
            //No triggers pressed
        }
        else if (rightTrigger > 0 && leftTrigger > 0)
        {
            //Debug.Log("Both are pressed");
        }
    }
}


