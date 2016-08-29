using UnityEngine;
using System.Collections;
using stl = System.Collections.Generic;


public class Pickup : MonoBehaviour
{
    public string PlayerGameObjectName;
    private GameObject player;
    public Base_bullet addition;
    

    public void Start()
    {
        player = GameObject.Find(PlayerGameObjectName);
        Base_bullet[] a = player.GetComponents<Base_bullet>();
        int i = (int)Random.Range(0, a.Length);
        Debug.Log(i);
        addition = a[(int)Random.Range(0, a.Length)];
        
    }

    void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject.name);
        if (collider.gameObject.name == player.name)
        {
            if (addition)
                player.GetComponent<inventory>().PickupPowerup(addition);
            else
                Debug.Log("kys");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
