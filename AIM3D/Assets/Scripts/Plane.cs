using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

    private float speed = 90f;
    private int i;

    private float incrementer = 0f;

    private float angleZ;


    /*
    if(angleZ > 180f && angleZ < 270f)
    {
        angleZ = 270f;
    }   
    else if (angleZ < 180 && angleZ > 90f)
    {
        angleZ = 90f;
    }
    */       
    
    void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * Time.deltaTime * 50f;
        float maxSpeed = 160f;

        if (Input.GetKey("space") || Input.GetButton("A"))
        {
            speed++;
			Debug.Log("Speed UP");
            maxSpeed = 200f;
        }

        //minimum & maximum speed
        if (speed < 45f)
        {
            speed = 45f;
        }
        else if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        //transform.Rotate(Input.GetAxis("Vertical") * 1.5f, 0.0f);

        //angleZ = new Vector3(Mathf.Clamp(Time.time, 90, 270));
        
        if(Input.GetAxis("Vertical") > 0)
        {
            //go up
            transform.Rotate(new Vector3(1.5f, 0f, 0f), Space.Self);

            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 82)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            //go down
            transform.Rotate(new Vector3(-1.5f, 0, 0), Space.Self);

            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 90)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }

        //Debug.Log(transform.rotation.x);
        //rotate plane banking
        if (Input.GetAxis("Horizontal") > 0f)
        {
            //bank & turn right
            transform.Rotate(new Vector3(0, 2, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, -2f), Space.Self);

            if(transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 280)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 280);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            //bank & turn left
            transform.Rotate(new Vector3(0, -2, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, 2f), Space.Self);

            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 180)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 80);
            }
        }
        else if (Input.GetAxis("Horizontal") == 0f)
        {
            //rotate plane back to 0 over Z axis
            if (transform.rotation.eulerAngles.z < 358 && transform.rotation.eulerAngles.z > 270)
            {
                //if plane is rotated to the right
                transform.Rotate(new Vector3(0, 0, 2) * 2, Space.Self);
            }
            else if (transform.rotation.eulerAngles.z > 2 && transform.rotation.eulerAngles.z < 90)
            {
                //if plane is rotated to the left
                transform.Rotate(new Vector3(0, 0, -2) * 2, Space.Self);
            }
        }

        //set maximum rotation for plane on Z axis

        /*
        float clampedZ = ClampAngle(transform.rotation.eulerAngles.z, 0, 10);
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = clampedZ;
        Debug.Log(clampedZ);
        transform.rotation.SetEulerAngles(rot);
        */
        Debug.Log(transform.rotation.eulerAngles.z);   
    }

    float ClampAngle(float angle, float min, float max)
    {
        if(angle < 90 || angle > 270)
        {
            if (angle > 180)
                angle -= 360;
            if (max > 180)
                max -= 360;
            if (min > 180)
                min -= 360;
        }
        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0)
            angle += 360;
        return angle;
    }
}
