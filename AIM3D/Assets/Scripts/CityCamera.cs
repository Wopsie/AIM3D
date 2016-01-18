using UnityEngine;
using System.Collections;

public class CityCamera : MonoBehaviour 
{
    private Camera cityCam;
    

	void Start () 
    {
        cityCam = GetComponent<Camera>();
        cityCam.enabled = false;
	}

    public void MoveCamAround()
    {
        Camera.main.enabled = false;
        cityCam.enabled = true;
        StartCoroutine("MoveAround");
        Debug.Log("MOVE CAM AROUND");
    }

    IEnumerator MoveAround()
    {
        for (int i = 0; i < 500; i++ )
        {
            transform.LookAt(new Vector3(-109f, 219f, -1321f));
            transform.Translate(Vector3.left * Time.deltaTime);
            yield return new WaitForSeconds(0f);
        }
    }
}
