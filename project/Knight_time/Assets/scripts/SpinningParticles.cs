using UnityEngine;
using System.Collections.Generic;

public class SpinningParticles : MonoBehaviour {

    public GameObject particle;
    public int NumParticles;
    public float StartingDistance;
    public GameObject StartWith;
    public float ZDistance;
    public float RotationSpeed;
    public float DamageWithSpeedInMind;

    public float Damage;
    public float BaseDamage;

    public List<GameObject> particles;

	// Use this for initialization
	void Start () {
        particles = new List<GameObject>();
        float f = 2 * Mathf.PI / NumParticles;
        for (int i = 0; i < NumParticles; ++i)
        {
            Vector3 v = new Vector3(StartingDistance * Mathf.Sin(f * i), StartingDistance * Mathf.Cos(f * i), ZDistance);
            GameObject go;
            particles.Add(go = Instantiate(particle, transform) as GameObject);
            go.transform.localPosition = v;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = transform.rotation.eulerAngles;
        v.z += RotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(v);
        Damage = DamageWithSpeedInMind * (RotationSpeed / 700) + BaseDamage;
	}
}
