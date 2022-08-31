using UnityEngine;

public class Charm_Particle : MonoBehaviour
{

    ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
