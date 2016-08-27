using UnityEngine;
using System.Collections;

public class PhysicsBulletL : Base_bullet {
    public float MaxLaunchSpeed;
    public float ShotRandomness;
    public float ShotRandomnessThreshold;
    public GameObject SpawnPrefab;
    public float LaunchSpeedMultiplier;
    public float ForwardBaseSpeed;
    public Vector3 BulletRelativeSpawnPosition;
    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    public override void OnMouseUp()
    {
        Transform t = GetComponent<Transform>();

        GameObject obj = Instantiate(SpawnPrefab, t.position + t.TransformDirection(BulletRelativeSpawnPosition), t.rotation) as GameObject;

        Rigidbody rb = obj.GetComponent<Rigidbody>();

        Vector3 v = new Vector3(Random.Range(
            (-((ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold)) > 0 ? 0 : (-((ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold)),
            (((ShotRandomnessThreshold - HeldDownFor)) / ShotRandomnessThreshold)) > 0 ? 0 : (((ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold)), 0);

        v *= ShotRandomness;

        rb.velocity = (t.forward * ((HeldDownFor > MaxLaunchSpeed ? MaxLaunchSpeed : HeldDownFor) * LaunchSpeedMultiplier + ForwardBaseSpeed)) + v;
        rb.useGravity = false;
    }
}
