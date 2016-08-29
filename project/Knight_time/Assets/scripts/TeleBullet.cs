using UnityEngine;
using System.Collections;

public class TeleBullet : Base_bullet
{
    public GameObject SpawnPrefab;
    public float ForwardBaseSpeed;
    public Vector3 BulletRelativeSpawnPosition;

    private bool dicksOut = false;
    private GameObject lastBullet;
	public AudioClip Charge;

    public override void OnMouseUp()
    {
        if(dicksOut == true)
        {
            dicksOut = false;

            transform.position = lastBullet.transform.position;
			lastBullet.GetComponent<AudioSource> ().PlayOneShot (Charge, 1);
            Destroy(lastBullet);
        }
        else
        {
            dicksOut = true;
            Transform t = GetComponent<Transform>();

            lastBullet = Instantiate(SpawnPrefab, t.position + t.TransformDirection(BulletRelativeSpawnPosition), t.rotation) as GameObject;

            Rigidbody rb = lastBullet.GetComponent<Rigidbody>();

            rb.velocity = t.forward * ForwardBaseSpeed;
            rb.useGravity = false;
        }
    }

    public override void OnAltFireDown()
    {
        if(dicksOut == true)
        {
            Destroy(lastBullet);
            dicksOut = false;
        }
    }
}
