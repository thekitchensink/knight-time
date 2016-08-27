using UnityEngine;
using System.Collections;

public class KillYourself : MonoBehaviour {

    public float KillTime;
    private float TrackTime = 0;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        TrackTime += Time.deltaTime;
        if(KillTime < TrackTime)
        {
            Destroy(gameObject);
        }
    }
}
