using UnityEngine;
using System.Collections;
using gen = System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Effect;
    public GameObject modifyRender;
    public ParticleSystem ps;
    public GameObject RootToDestroy;
    public int StartingHealth;
    public int CurrentHealth;

    private bool IsDying = false;
    private float TimeTracker = 0.0f;

    public gen.List<Collider> Disable;

	private AudioSource s;

    // Use this for initialization
    void Start () {
		s = GetComponent<AudioSource> ();
        CurrentHealth = StartingHealth;
    }
    
    // Update is called once per frame
    void Update () {
        if(IsDying)
        {
            if(2.0f < (TimeTracker += Time.deltaTime))
            {
                Destroy(RootToDestroy);
            }
        }
    }

    public void TakeDamage(int amount)
    {
		s.pitch = Random.Range (0.7f, 1f);
		s.PlayOneShot (s.clip, 0.1f);

        Debug.Log(amount);
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
			s.pitch = Random.Range (0.7f, 1f);
			s.PlayOneShot (s.clip, 0.6f);

            if (Effect == null)
            {
                if (ps == null)
                    return;
                ps.Play();
                SkinnedMeshRenderer smr = modifyRender.GetComponent<SkinnedMeshRenderer>();
                if (smr) smr.enabled = false;
                else
                {
                    MeshRenderer mr = modifyRender.GetComponent<MeshRenderer>();
                    if (mr) mr.enabled = false;
                    BaseMaceAI bma = modifyRender.GetComponent<BaseMaceAI>();
                    if(bma)
                    bma.Speed = 0;
                }

               // modifyRender.enabled = false;
                IsDying = true;
                foreach (Collider c in Disable)
                {
                    c.enabled = false;
                }
            }
            else
            {
                Instantiate(Effect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
