using UnityEngine;
using System.Collections;
using System;

public class LaunchPlayerOnHit : MonoBehaviour {

    public GameObject GameObjectTrigger;
    public GameObject BehaviourObject;

    private BaseMaceAI comp;
	// Use this for initialization
	void Start () {
        comp = BehaviourObject.GetComponent<BaseMaceAI>();
        if(GameObjectTrigger == null)
        {
            GameObjectTrigger = GameObject.Find("FPSController");
        }
   	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObjectTrigger)
        {
            comp.LaunchThePlayer();
        }
    }
}
