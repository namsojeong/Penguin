
using UnityEngine;

public class Charm_Particle : MonoBehaviour
{

    ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
