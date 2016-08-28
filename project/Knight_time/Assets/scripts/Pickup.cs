using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public GameObject player;
    public Base_bullet addition;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject == player)
        {
            player.GetComponent<inventory>().PickupPowerup(addition);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
  
    }
}
