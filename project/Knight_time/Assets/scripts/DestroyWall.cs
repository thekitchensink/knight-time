using UnityEngine;
using System.Collections;

public class DestroyWall : MonoBehaviour {

    private int health = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
      Base_bullet one = coll.gameObject.GetComponent<Base_bullet>();
      KillYourself two = coll.gameObject.GetComponent<KillYourself>();

        print("fuck");

      if (one || two)
      {
        health--;
        
        if(health <= 0)
            Destroy(gameObject);
      }
    }

}
