using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

    private float speed = 90f;
    private int i;
    public Vector3 playerRot;
    
    void Update()
    {
        playerRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    
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

        //rotate plane banking
        if (Input.GetAxis("Horizontal") > 0f)
        {
            //bank & turn right
            transform.Rotate(new Vector3(0, 2, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, -2.8f), Space.Self);

            if(transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 280)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 280);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            //bank & turn left
            transform.Rotate(new Vector3(0, -2, 0), Space.World);
            transform.Rotate(new Vector3(0f, 0f, 2.8f), Space.Self);

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
    }
}
