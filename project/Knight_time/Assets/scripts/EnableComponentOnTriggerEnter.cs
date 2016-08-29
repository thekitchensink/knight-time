using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof (Collider))]

public class EnableComponentOnTriggerEnter : MonoBehaviour {
    private FirstPersonController FPC;
    private RigidbodyFirstPersonController RFPC;
    private Rigidbody RB;
    private CharacterController CC;
    private CapsuleCollider COL;

    public GameObject Target;
    public float MaxFlyTime = 5.0f;

    private bool Flying = false;
    private float TimeTracker = 0;
    // Use this for initialization
    void Start () {
        FPC = Target.GetComponent<FirstPersonController>();
        RFPC = Target.GetComponent<RigidbodyFirstPersonController>();
        RB = Target.GetComponent<Rigidbody>();
        CC = Target.GetComponent<CharacterController>();
        COL = Target.GetComponent<CapsuleCollider>();
    }
    
    // Update is called once per frame
    void Update () {
        if(Flying && (TimeTracker += Time.deltaTime) > MaxFlyTime)
        {
            Landed();
        }
    }

    public void Launch()
    {
        FPC.enabled = false;
        CC.enabled = false;
        RFPC.enabled = true;
        COL.enabled = true;
        RB.isKinematic = false;
  //      Debug.Log("launch");

        Flying = true;
        TimeTracker = 0;
    }
    public void Landed()
    {
        FPC.enabled = true;
        CC.enabled = true;
        RFPC.enabled = false;
        COL.enabled = false;
        RB.isKinematic = true;
//        Debug.Log("land");

        Flying = false;
    }

    public void OnTriggerEnter()
    {
        Landed();
    }

    public void OnTriggerExit()
    {
      //  Launch();
    }
}
