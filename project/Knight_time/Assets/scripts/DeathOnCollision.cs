using UnityEngine;
using System.Collections;

public class DeathOnCollision : MonoBehaviour
{
    public GameObject ParticleEffect;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(ParticleEffect);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Instantiate(ParticleEffect);
        Destroy(gameObject);
    }
}
