using UnityEngine;
using System.Collections;

public class TeleBullet : Base_bullet
{
    public GameObject SpawnPrefab;
    public float ForwardBaseSpeed;
    public Vector3 BulletRelativeSpawnPosition;

    private bool dicksOut = false;
    private GameObject lastBullet;

    public override void OnMouseUp()
    {
        if(dicksOut == true)
        {
            dicksOut = false;

            transform.position = lastBullet.transform.position;
			GetComponent<inventory>().ammoCount[GetComponent<inventory>().current_type] -= 1;
            Destroy(lastBullet);
        }
		else if(GetComponent<inventory>().ammoCount[GetComponent<inventory>().current_type] > 0)
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
