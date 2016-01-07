using UnityEngine;
using System.Collections;

public class KillPlane : MonoBehaviour {

    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject);
        Debug.Log("each day we stray further from gods light...");
    }
}
