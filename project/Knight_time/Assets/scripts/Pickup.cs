using UnityEngine;
using System.Collections;
using stl = System.Collections.Generic;


public class Pickup : MonoBehaviour
{
    public string PlayerGameObjectName;
    private GameObject player;
    public Base_bullet addition;
    public stl.List<Material> mats;
    public void Start()
    {
        player = GameObject.Find(PlayerGameObjectName);
        Base_bullet[] a = player.GetComponents<Base_bullet>();
        int i = Random.Range(0, a.Length + 1);
        if(i == a.Length)
        {
            addition = null;
        }
        else
            addition = a[i];

        GetComponent<MeshRenderer>().material = mats[i];
    }

    void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject.name);
        if (collider.gameObject.name == player.name)
        {
            if (addition)
                player.GetComponent<inventory>().PickupPowerup(addition);
            else
                PlayerHealth.AddHealth(30);
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
