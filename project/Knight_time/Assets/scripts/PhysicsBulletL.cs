using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhysicsBulletL : Base_bullet {
    public float MaxLaunchSpeed;
    public float ShotRandomness;
    public float ShotRandomnessThreshold;
    public GameObject SpawnPrefab;
    public float LaunchSpeedMultiplier;
    public float ForwardBaseSpeed;
    public Vector3 BulletRelativeSpawnPosition;
    public Vector3 BulletRelativeSpawnScale;
    public Vector3 BulletRelativeFinalSpawnScale;
    public float StartingBulletRotationSpeed;
    public float EndingBulletRotationSpeed;

    private GameObject g;
    // Use this for initialization
    void Start () {
        //Reticle.GetComponent<Image>().canvasRenderer.SetColor(c);
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    public override void Frame_Mouse_Is_Down()
    {
        // Vector3 v2 = new Vector3((ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold, (ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold, 1);
        // Debug.Log(v2);
        // if(v2.x < 0.1f)
        // {
        //     v2 = new Vector3(0.1f, 0.1f, 0.1f);
        // }
        // Reticle.transform.localScale = v2;
        // Debug.Log(Reticle.GetComponent<Image>().canvasRenderer.GetColor());
        g.GetComponent<SpinningParticles>().RotationSpeed = Mathf.Lerp(StartingBulletRotationSpeed, EndingBulletRotationSpeed, HeldDownFor / ShotRandomnessThreshold);
        g.transform.localScale = Vector3.Slerp(BulletRelativeSpawnScale, BulletRelativeFinalSpawnScale, HeldDownFor / ShotRandomnessThreshold);
        Quaternion q = g.transform.localRotation;
        Vector3 v = q.eulerAngles;
        v.x = 0;
        v.y = 0;
        q.eulerAngles = v;
        g.transform.localRotation = q;
        g.GetComponent<KillYourself>().TrackTime = 0;
    }
    public override void OnMouseDown()
    {
   //     Debug.Log("Fuck");
        // Reticle.GetComponent<Image>().CrossFadeColor(color, ReticleFadeInTime, false, true);
        g = Instantiate(SpawnPrefab, transform) as GameObject;
        g.transform.localPosition = BulletRelativeSpawnPosition;
        g.transform.localRotation = Quaternion.identity;
        g.GetComponent<SpinningParticles>().RotationSpeed = StartingBulletRotationSpeed;
    }
    public override void Frame_Mouse_Is_Up()
    {
        //Reticle.GetComponent<Image>().canvasRenderer.SetColor(c);
    }
    public override void OnMouseUp()
    {
        Transform t = GetComponent<Transform>();

        Rigidbody rb = g.GetComponent<Rigidbody>();
        Vector3 v = new Vector3(Random.Range(
            (-((ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold)) > 0.0f ? 0 : (-((ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold)),
            (((ShotRandomnessThreshold - HeldDownFor)) / ShotRandomnessThreshold) < 0.0f ? 0 : (((ShotRandomnessThreshold - HeldDownFor) / ShotRandomnessThreshold))), 0);

        v *= ShotRandomness;

        rb.velocity = (t.forward * ((HeldDownFor > MaxLaunchSpeed ? MaxLaunchSpeed : HeldDownFor) * LaunchSpeedMultiplier + ForwardBaseSpeed)) + v;
        rb.useGravity = false;
        //Reticle.GetComponent<Image>().canvasRenderer.SetColor(c);
 //       Debug.Log("Bitches ain't shit but hoes and tricks");
        g.transform.SetParent(null);
    }
}
