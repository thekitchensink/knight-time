using UnityEngine;
using System.Collections;

public class AttackPlayerWhenNear : MonoBehaviour {
    private GameObject Player;
    private Animator a;
    public float AttackDist;
    private float TimeSoFar = 0.0f;
    public float f;
    public int DamageAmount;
    // Use this for initialization
    void Start () {
        a = GetComponent<Animator>();
        a.applyRootMotion = true;
        Player = GameObject.Find("FPSController");
    }
    
    // Update is called once per frame
    void Update () {
        transform.LookAt(Player.transform);
        Vector3 eulerang = transform.eulerAngles;
        eulerang.y -= 45;
        transform.eulerAngles = eulerang;
        if(Vector3.Distance(transform.position, Player.transform.position) < AttackDist)
        {
            a.SetBool("Swinging", true);
            TimeSoFar += Time.deltaTime;
        }
        else
        {
            a.SetBool("Swinging", false);
            TimeSoFar = 0;
        }
        if(TimeSoFar > f / 2)
        {
            Debug.Log("kys");
            TimeSoFar = -f / 2;

            PlayerHealth.TakeDamage(DamageAmount);
        }
    }
}
