using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour 
{
    public GameObject laser;

    public enum Shots
    {
        Laser,
        Missile
    }

    public Dictionary<Shots, GameObject> shooter = new Dictionary<Shots, GameObject>();
    private Shots shots;

	void Start () 
    {
        shooter.Add(Shots.Laser, laser);
	}

    public void Shoot()
    {
        var projectile = (GameObject)Instantiate(shooter[shots], transform.position, transform.rotation);
    }
}
