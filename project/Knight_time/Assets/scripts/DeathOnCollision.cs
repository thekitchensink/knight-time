﻿using UnityEngine;
using System.Collections;

public class DeathOnCollision : MonoBehaviour
{
    public GameObject ParticleEffect;
	private Transform t;
    private SpinningParticles sp;
    // Use this for initialization
    void Start()
    {
        sp = gameObject.transform.parent.gameObject.GetComponent<SpinningParticles>();
		t = transform.FindChild ("GunParticles");
        if(sp == null)
        {
            throw new FuckYou();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        EnemyHealth eh;
        // don't turn this into == I know what I am doing pls
        if(eh = collision.collider.gameObject.GetComponent<EnemyHealth>())
        {
            eh.TakeDamage((int)sp.Damage);
        }

		KillYourself k = t.gameObject.AddComponent<KillYourself> ();
		k.KillTime = 4;
		t.parent = null;
		t.localScale = Vector3.one * 5;

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
        DestroyWall wall = other.gameObject.GetComponent<DestroyWall>();
        if (wall)
        {
            if (wall.enable)
                wall.health--;

            if (wall.health <= 0)
            {
                GameObject g = GameObject.Instantiate(Resources.Load("SmokeDust") as GameObject);
                g.GetComponent<Transform>().position = other.gameObject.transform.position;

                Destroy(other.gameObject);
            }
        }

		KillYourself k = t.gameObject.AddComponent<KillYourself> ();
		k.KillTime = 4;
		t.parent = null;
		t.localScale = Vector3.one * 5;

        if (ParticleEffect != null)
            Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
