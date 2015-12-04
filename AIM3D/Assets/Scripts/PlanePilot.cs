using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour {

    public float speed = 90f;

	void FixedUpdate () 
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10f + Vector3.up * 5f;
        float bias = 0.90f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1f-bias);
        Camera.main.transform.LookAt( transform.position + transform.forward * 60f);

        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * Time.deltaTime * 50f;

        //minimum & maximum speed
        if(speed < 45f)
        {
            speed = 45f;
        }else if(speed > 160f)
        {
            speed = 160f;
        }

        transform.Rotate(Input.GetAxis("Vertical") *1.5f , 0.0f, -Input.GetAxis("Horizontal") * 1.8f);

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if(terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeightWhereWeAre, transform.position.z);
        }
	}
}