using UnityEngine;
using System.Collections;

public class fuckwitheverything : MonoBehaviour {
    private Vector3 targetScale;
    private Vector3 oldScale;
    public float speed;
    private float timesinceFuck;
    public float MaxFuck;
    public float MinFuck;

    public float MaxRotationFuck;
    public float MinRotationFuck;

    // Use this for initialization
    void Start () {
        targetScale = transform.localScale;
        Init();
    }
    
    // Update is called once per frame
    void Update () {
        if(FuckWithIt())
        {
            Init();
        }
    }

    bool FuckWithIt()
    {
        transform.localScale = Vector3.Slerp(oldScale, targetScale, (Time.deltaTime + timesinceFuck)/speed);
        timesinceFuck += Time.deltaTime;
        if (timesinceFuck > speed)
            return true;
        return false;
    }

    void Init()
    {
        oldScale = targetScale;
        float f = Random.Range(MinFuck, MaxFuck);
        targetScale = new Vector3(f, f, f);
        timesinceFuck = 0;

        GetComponent<SpinningParticles>().RotationSpeed = Random.Range(MinRotationFuck, MaxRotationFuck);
    }
}
