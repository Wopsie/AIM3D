using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{

    [SerializeField]    private GameObject explosion;
    [SerializeField]    private AudioSource explosionSound;

    public void Death()
    {
        StartCoroutine("DeathEvent");
    }

    
    IEnumerator DeathEvent()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosionSound.Play();
        Debug.Log("explode");
        yield return new WaitForSeconds(5f);
    }
}
