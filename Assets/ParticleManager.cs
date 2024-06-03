using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleManager : MonoBehaviour
{
    public GameObject ParticleParent;
    public GameObject ParticlePrefab;
    
    public void CreateParticle(Vector3 position, Vector3 force, ElementObject element) {
        var particle = Instantiate(ParticlePrefab, position, Quaternion.identity);
        particle.GetComponent<Particle>().Element = element;
        particle.GetComponent<Rigidbody2D>().AddForce(force);
        particle.transform.SetParent(ParticleParent.transform);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
