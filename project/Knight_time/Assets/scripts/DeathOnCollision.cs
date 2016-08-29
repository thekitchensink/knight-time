using UnityEngine;
using System.Collections;

public class DeathOnCollision : MonoBehaviour
{
    public GameObject ParticleEffect;
    private SpinningParticles sp;

	private Transform particleT;

    // Use this for initialization
    void Start()
    {
        sp = gameObject.transform.parent.gameObject.GetComponent<SpinningParticles>();

		if (sp == null)
			Destroy (this);

		particleT = transform.FindChild ("GunParticles");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
	{
		EnemyHealth eh;
		// don't turn this into == I know what I am doing pls
		if (eh = collision.collider.gameObject.GetComponent<EnemyHealth> ()) {
			eh.TakeDamage ((int)sp.Damage);
		}

		if (particleT != null){
			particleT.parent = null;
			particleT.localScale = Vector3.one * 5;
			KillYourself k = particleT.gameObject.AddComponent<KillYourself> ();
			k.KillTime = 3f;
		}

        if(ParticleEffect != null)
            Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        EnemyHealth eh;
        if (eh = other.gameObject.GetComponent<EnemyHealth>())
        {
            eh.TakeDamage((int)sp.Damage);
        }

		if (particleT != null) {
			particleT.parent = null;
			particleT.localScale = Vector3.one * 5;
			KillYourself k = particleT.gameObject.AddComponent<KillYourself> ();
			k.KillTime = 3f;
		}
		if(ParticleEffect != null)
        	Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
