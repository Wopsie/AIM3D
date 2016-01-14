using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{

    [SerializeField]    private GameObject explosion;
    private AudioSource explosionSound;
    private GameObject mainCam;

    void Start()
    {
        //get audiosource and camera
        mainCam = GameObject.FindWithTag("MainCamera");
        explosionSound = mainCam.GetComponent<AudioSource>();
    }

    public void Death()
    {
        StartCoroutine("DeathEvent");
    }

    //instantiate explosion, play explosion sound
    IEnumerator DeathEvent()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosionSound.Play();
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
