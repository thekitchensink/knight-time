using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public GameObject player;
    public Base_bullet addition;

    void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject.name);
      if(collider.gameObject.name == player.name)
      {
        if(addition)
          player.GetComponent<inventory>().PickupPowerup(addition);

        Destroy(this.gameObject);
      }
    }

    // Update is called once per frame
    void Update () {
  
    }
}
