using UnityEngine;
using System.Collections;

public class KillYourself : MonoBehaviour {

    public float KillTime;
    public float TrackTime = 0;
    static bool ONLYBEONE = false;
    private bool ISetItTo = true;
    public static bool TrackInstances;
    // Use this for initialization
    void Start () {
        ISetItTo = ONLYBEONE = !ONLYBEONE;
        TrackTime = 0;
    }
    
    // Update is called once per frame
    void Update () {
        TrackTime += Time.deltaTime;
        if(KillTime < TrackTime)
        {
            Destroy(gameObject);
        }
        if (TrackInstances)
        {
            if (ONLYBEONE != ISetItTo)
            {
                Destroy(gameObject);
            }
        }
    }
}
