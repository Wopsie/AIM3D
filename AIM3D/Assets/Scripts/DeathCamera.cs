using UnityEngine;
using System.Collections;

public class DeathCamera : MonoBehaviour {

    private float camSpeed = 5f;
    private Camera deathCamera;

    void Start()
    {
        deathCamera = GetComponent<Camera>();
    }

    public void MoveCamBack()
    {
        //deathCamera.enabled = true;
        StartCoroutine("Moveback");
    }

    IEnumerator MoveBack()
    {
        transform.position -= transform.forward * Time.deltaTime * camSpeed;
        yield return new WaitForSeconds(5f);
    }
}
