using UnityEngine;
using System.Collections;

public class KillPlane : MonoBehaviour {

    //check collision with killplanes
    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject);
        Debug.Log("each day we stray further from the light...");
    }
}
