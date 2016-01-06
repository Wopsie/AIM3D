using UnityEngine;
using System.Collections;

public class StarParticle : MonoBehaviour 
{
    private Transform starParticle;
    private ParticleSystem.Particle[] stars;

    [SerializeField]    private int starMax = 100;
    [SerializeField]    private float starSize = 1f;
    [SerializeField]    private float starDist = 10f;
    [SerializeField]    private float starClipDist = 1f;

    private float starDistSqr;
    private float starClipDistSqr;

	void Start () 
    {
        starParticle = transform;
        starClipDistSqr = starClipDist * starClipDist;
        starDistSqr = starDist * starDist;
	}
        
    private void CreateStar()
    {
        stars = new ParticleSystem.Particle[starMax];

        for(int i = 0; i < starMax; i++)
        {
            stars[i].position = Random.insideUnitSphere * starDist + starParticle.position;
            stars[i].color = new Color(1,1,1,1);
            stars[i].size = starSize;
        }
    }

    void Update()
    {
        if(stars == null)
        {
            CreateStar();
        }

        for(int i = 0; i < starMax; i++)
        {
            if((stars[i].position - starParticle.position).sqrMagnitude > starDistSqr)
            {
                stars[i].position = Random.insideUnitSphere.normalized * starDist + starParticle.position;
            }
            
            if((stars[i].position - starParticle.position).sqrMagnitude <= starClipDistSqr)
            {
                float percent = (stars[i].position - starParticle.position).sqrMagnitude / starClipDistSqr;

                stars[i].color = new Color(1, 1, 1, percent);
                stars[i].size = percent * starSize;
            }

            GetComponent<ParticleSystem>().SetParticles(stars, stars.Length);
        }
    }
}
